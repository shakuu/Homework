(function() {
  window.onload = function() {
    var createMessageItem, meInput, meMessages, otherInput, otherMessages;
    createMessageItem = function(className, author, text) {
      var li;
      li = document.createElement('li');
      li.className = className;
      li.innerHTML = '<strong>' + 'by ' + author + '</strong>' + '<span>' + text + '</span>';
      return li;
    };
    meInput = document.querySelector('#me input');
    meMessages = document.querySelector('#me ul');
    otherInput = document.querySelector('#other input');
    otherMessages = document.querySelector('#other ul');
    (document.querySelector('#me button')).addEventListener('click', function(ev) {
      var msgText;
      msgText = meInput.value;
      meInput.value = '';
      if (!msgText) {
        return;
      }
      meMessages.appendChild(createMessageItem('me', 'me', msgText));
      return otherMessages.appendChild(createMessageItem('other', 'Doncho Minkov', msgText));
    });
    return (document.querySelector('#other button')).addEventListener('click', function(ev) {
      var msgText;
      msgText = otherInput.value;
      otherInput.value = '';
      if (!msgText) {
        return;
      }
      otherMessages.appendChild(createMessageItem('me', 'me', msgText));
      return meMessages.appendChild(createMessageItem('other', 'Ivaylo Kenov', msgText));
    });
  };

}).call(this);
