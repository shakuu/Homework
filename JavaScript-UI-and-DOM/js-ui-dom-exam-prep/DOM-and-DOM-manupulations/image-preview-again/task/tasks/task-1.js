/* globals module */

function solve() {
    return function (selector, items) {
        'use strict';
        if (typeof selector !== 'string') {
            return;
        }
        var root = document.querySelector(selector);
        if (!root) {
            return;
        }

        var fragment = document.createDocumentFragment(),

            imagePreview,
            imagePreviewImage,
            imagePreviewTitle,

            imageList,

            imageListLabel,
            imageListFilter,

            imageContainerTemplate,
            imageContainerHeading,
            imageContainerImage,

            allImages;

        // Build Preview 
        imagePreview = document.createElement('div');
        imagePreview.className += ' image-preview';

        imagePreviewImage = document.createElement('img');
        imagePreviewTitle = document.createElement('h1');

        imagePreview.appendChild(imagePreviewTitle);
        imagePreview.appendChild(imagePreviewImage);
        applyImagePreviewStyle(imagePreview);
        fragment.appendChild(imagePreview);

        // Build List
        imageList = document.createElement('div');
        imageList.style.display = 'inline-block';
        imageList.style.width = '200px';
        imageList.style.height = '400px';
        imageList.style.overflowY = 'scroll';
        imageList.style.textAlign = 'center';

        imageListLabel = document.createElement('label');
        imageListLabel.innerHTML = 'Filter';
        imageListLabel.style.display = 'block';
        imageListFilter = document.createElement('input');
        imageListFilter.style.display = 'block';

        imageListLabel.appendChild(imageListFilter);
        imageList.appendChild(imageListLabel);
        fragment.appendChild(imageList);

        // Build image-container temaplate
        imageContainerTemplate = document.createElement('div');
        imageContainerTemplate.style.textAlign = 'center';
        imageContainerTemplate.className += ' image-container';
        imageContainerHeading = document.createElement('h3');
        imageContainerHeading.style.display = 'block';
        imageContainerImage = document.createElement('img');
        imageContainerImage.style.width = '85%';

        imageContainerTemplate.appendChild(imageContainerHeading);
        imageContainerTemplate.appendChild(imageContainerImage);

        // Create Image containers
        items.forEach(function (element, index) {
            imageContainerHeading.innerHTML = element.title;
            imageContainerImage.src = element.url;
            imageList.appendChild(imageContainerTemplate.cloneNode(true));
        });

        // EVENTS
        allImages = document.getElementsByClassName('image-container');
        imageList.addEventListener('click', setImagePreviewImage);
        imageList.addEventListener('mouseenter', highlightImageContainer, true);
        imageList.addEventListener('mouseleave', resetImageContainer, true);
        imageListFilter.addEventListener('input', filterImages);

        function filterImages(event) {
            var query = imageListFilter.value.toLowerCase();

            for (var i = 0, len = allImages.length; i < len; i += 1) {
                var value = allImages[i].querySelector('h3').innerHTML.toLowerCase();

                if (value.indexOf(query) < 0) {
                    allImages[i].style.display = 'none';
                } else {
                    allImages[i].style.display = '';
                }
            }
        }

        function highlightImageContainer(event) {
            var clicked = event.target;

            while (clicked.parentNode && clicked.className.indexOf('image-container') < 0) {
                clicked = clicked.parentNode;
            }
            if (!clicked.style) {
                return;
            }
            clicked.style.backgroundColor = 'grey';
        }

        function resetImageContainer(event) {
            var clicked = event.target;

            if (clicked.className.indexOf('image-container') < 0) {
                return;
            }

            clicked.style.backgroundColor = '';
        }

        function setImagePreviewImage(event) {
            var clicked = event.target;

            while (clicked.parentNode && clicked.className.indexOf('image-container') < 0) {
                clicked = clicked.parentNode;
            }

            imagePreviewTitle.innerHTML = clicked.querySelector('h3').innerHTML;
            imagePreviewImage.src = clicked.querySelector('img').src;
        }

        function applyImagePreviewStyle(preview) {
            preview.style.display = 'inline-block';
            preview.style.width = '500px';
            preview.style.height = '400px';
            preview.style.textAlign = 'center';

            preview.querySelector('img').style.width = '90%';
        }

        // Initial State
        imagePreviewImage.src = items[0].url;
        imagePreviewTitle.innerHTML = items[0].title;
        root.appendChild(fragment);
    };
}

module.exports = solve;