$(() => { // on document ready
  const GLYPH_UP = 'glyphicon-chevron-up',
    GLYPH_DOWN = 'glyphicon-chevron-down',
    root = $('#root'),
    navbar = root.find('nav.navbar'),
    mainNav = navbar.find('#main-nav'),
    contentContainer = $('#root #content-fluid'),
    loginForm = $('#login'),
    logoutForm = $('#logout'),
    usernameSpan = $('#span-username'),
    usernameInput = $('#login input'),
    alertTemplate = $($('#alert-template').text());

  (function checkForLoggedUser() {
    data.users.current()
      .then((user) => {
        if (user) {
          usernameSpan.text(user);
          loginForm.addClass('hidden');
          logoutForm.removeClass('hidden');
        }
      });
  })();

  const app = Sammy('#root #content-fluid', function () {
    this.get('/', function () {
      contentContainer.html('');
    });

    this.get('#/', function () {
      contentContainer.html('');
    });

    this.get('#/threads', function () {
      Promise.all([
        data.threads.get(),
        data.templates.get('thread'),
        data.templates.get('threads-container'),
        data.templates.get('thread-new')
      ])
        .then(([content, threads, container, add]) => {
          const compiledThreads = threads(content.result);
          const newThread = add(null);
          const html = container({
            threads: compiledThreads,
            add: newThread
          });
          contentContainer.html(html);
        });
    });

    this.get('#/threads/add', function () {
      
    });

    this.get('#/threads/:id', (route) => {
      let threadId = route.params.id;
      Promise.all([
        data.threads.getById(threadId),
        data.templates.get('message'),
        data.templates.get('messages-container'),
        data.templates.get('message-new')
      ])
        .then(([content, messages, container, add]) => {
          const compiledMessages = messages(content.result.messages);
          const newMessage = add(null);
          const html = container({
            id: content.result.id,
            title: content.result.title,
            messages: compiledMessages,
            add: newMessage
          });

          contentContainer.append(html);
        });
    });

    this.get('#/gallery', function () {
      data.gallery.get()
        .then(loadGalleryContent)
        .catch(console.log);
    });
  });

  app.run('#/');

  function showMsg(msg, type, cssClass, delay) {
    let container = alertTemplate.clone(true)
      .addClass(cssClass).text(`${type}: ${msg}`)
      .appendTo(root);

    setTimeout(() => {
      container.remove();
    }, delay || 2000)
  }

  function loadGalleryContent(data) {
    let list = data.data.children,
      containerGallery = $($('#gallery-container-tempalte').text()),
      containerImgs = containerGallery.find('#gallery-imgs'),
      item = $($('#gallery-img-tempalte').text()),
      itemImg = item.find('img.gallery-item-img'),
      itemTitle = item.find('.gallery-item-title')

    list.forEach((el) => {
      itemTitle.text(el.data.title);
      itemImg.attr('src', el.data.thumbnail);

      containerImgs.append(item.clone(true));
    });

    contentContainer.html('').append(containerGallery);
  }

  navbar.on('click', 'li', (ev) => {
    let $target = $(ev.target);
    $target.parents('nav').find('li').removeClass('active');
    $target.parents('li').addClass('active');
  });

  contentContainer.on('click', '#btn-add-thread', (ev) => {
    let title = $(ev.target).parents('form').find('input#input-add-thread').val() || null;
    data.threads.add(title)
      .then((thread) => {
        // loadThreadsContent([thread]);
      })
      .then(() => $('#btn-threads').trigger('click'))
      .then(showMsg('Successfuly added the new thread', 'Success', 'alert-success'))
      .catch((err) => showMsg(JSON.parse(err.responseText).err, 'Error', 'alert-danger'));
  })

  contentContainer.on('click', '.btn-add-message', (ev) => {
    let $target = $(ev.target),
      $container = $target.parents('.container-messages'),
      thId = $container.attr('data-thread-id'),
      msg = $container.find('.input-add-message').val();

    data.threads.addMessage(thId, msg)
      .then((message) => {
      })
      .then(() => {
        const btn = $('#thread-' + thId);
        btn.trigger('click');
      })
      .then(showMsg('Successfuly added the new mssagee', 'Success', 'alert-success'))
      .catch((err) => showMsg(JSON.parse(err.responseText).err, 'Error', 'alert-danger'));
  })

  contentContainer.on('click', '.btn-close-msg', (ev) => {
    let msgContainer = $(ev.target).parents('.container-messages').remove();
  });

  contentContainer.on('click', '.btn-collapse-msg', (ev) => {
    let $target = $(ev.target);
    if ($target.hasClass(GLYPH_UP)) {
      $target.removeClass(GLYPH_UP).addClass(GLYPH_DOWN);
    } else {
      $target.removeClass(GLYPH_DOWN).addClass(GLYPH_UP);
    }

    $target.parents('.container-messages').find('.messages').toggle();
  });
  // end threads

  // start login/logout
  navbar.on('click', '#btn-login', (ev) => {
    let username = usernameInput.val() || 'anonymous';
    data.users.login(username)
      .then((user) => {
        usernameInput.val('')
        usernameSpan.text(user);
        loginForm.addClass('hidden');
        logoutForm.removeClass('hidden');
      })
  });
  navbar.on('click', '#btn-logout', (ev) => {
    data.users.logout()
      .then(() => {
        usernameSpan.text('');
        loginForm.removeClass('hidden');
        logoutForm.addClass('hidden');
      })
  });
  // end login/logout
});