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

    });

    this.get('#/', function () {

    });

    this.get('#/threads', function () {
      Promise.all([
        data.threads.get(),
        data.templates.get('thread'),
        data.templates.get('threads-container')
      ])
        .then(([content, threads, container]) => {
          const compiledThreads = threads(content.result);
          const html = container(compiledThreads);
          contentContainer.html(html);
        });
    });

    this.get('#/threads/:id', (route) => {
      let threadId = route.params.id;
      data.threads.getById(threadId)
        .then(loadMessagesContent)
        .catch((err) => showMsg(err, 'Error', 'alert-danger'))
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

  // start threads
  function loadMessagesContent(data) {
    let container = $($('#messages-container-template').text()),
      messagesContainer = container.find('.panel-body');
    container.attr('data-thread-id', data.result.id);

    function getMsgUI(msg, author, date) {
      let template = $($('#messages-template').text());
      template.find('.message-content').text(msg.content);
      template.find('.message-creator').text(author || msg.username || 'anonymous');
      template.find('.message-date').text(date || msg.postDate || 'unknown');
      return template.clone(true);
    }
    function getAddNewMsgUI() {
      let template = $($('#message-new-template').html());
      return template.clone(true);
    }

    if (data.result.messages && data.result.messages.length > 0) {
      data.result.messages.forEach((msg) => {
        messagesContainer.append(getMsgUI(msg))
      })
    } else {
      messagesContainer.append(getMsgUI('No messages!'))
    }

    messagesContainer.append(getAddNewMsgUI());

    container.find('.thread-title').text(data.result.title);
    contentContainer.append(container);
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
        loadThreadsContent([thread]);
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
        loadMessagesContent([message]);
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