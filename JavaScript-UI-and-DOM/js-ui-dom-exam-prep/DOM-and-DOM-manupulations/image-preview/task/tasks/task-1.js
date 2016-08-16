/* globals module */

function solve() {
    return function (selector, items) {
        'use strict';
        var element,

            imagePreviewContainer,
            imagePreviewHeading,
            imagePreviewImage,

            imageListlabel,
            imageListInput,
            imageList,

            templateImageContainer,
            templateImageTitle,
            templateImage,

            allImageContainers;

        element = document.querySelector(selector);

        // Create Image Preview
        imagePreviewHeading = document.createElement('h1');
        imagePreviewHeading.innerHTML = items[0].title;

        imagePreviewImage = document.createElement('img');
        imagePreviewImage.src = items[0].url;

        imagePreviewContainer = document.createElement('div');
        imagePreviewContainer.className = 'image-preview';
        imagePreviewContainer.appendChild(imagePreviewHeading);
        imagePreviewContainer.appendChild(imagePreviewImage);

        element.appendChild(imagePreviewContainer);

        // Create List
        imageListInput = document.createElement('input');

        imageListlabel = document.createElement('label');
        imageListlabel.innerHTML = 'Filter';
        imageListlabel.appendChild(imageListInput);

        imageList = document.createElement('ul');
        imageList.appendChild(imageListlabel);

        // Create Template
        templateImageTitle = document.createElement('h2');
        templateImage = document.createElement('img');

        templateImageContainer = document.createElement('li');
        templateImageContainer.className = 'image-container';
        templateImageContainer.appendChild(templateImageTitle);
        templateImageContainer.appendChild(templateImage);

        // build list of images
        for (var index = 0, len = items.length; index < len; index += 1) {
            var newImage;

            templateImageTitle.innerHTML = items[index].title;
            templateImage.src = items[index].url;

            newImage = templateImageContainer.cloneNode(true);
            imageList.appendChild(newImage);
        }
        element.appendChild(imageList);
        allImageContainers = document.getElementsByClassName('image-container');

        imageList.addEventListener('mouseenter', applyBackgroundColor, true);
        imageList.addEventListener('mouseout', resetBackgroundColor, true);
        imageList.addEventListener('click', changeImagePreview, true);
        imageListInput.addEventListener('input', filterImageList);

        function filterImageList(event) {
            var query = imageListInput.value;

            for (var index = 0, len = allImageContainers.length; index < len; index += 1) {
                var headingContent;

                headingContent = allImageContainers[index].querySelector('h2').innerHTML;
                if (headingContent.indexOf(query) < 0) {
                    allImageContainers[index].style.display = 'none';
                } else {
                    allImageContainers[index].style.display = '';
                }
            }
        }

        function changeImagePreview(event) {
            var clicked,
                parent,
                title,
                url;

            clicked = event.target;
            parent = getParent(clicked);
            if (!parent) {
                return;
            }
            imagePreviewHeading.innerHTML = parent.querySelector('h2').innerHTML;
            imagePreviewImage.src = parent.querySelector('img').src;
        }

        function applyBackgroundColor(event) {
            var clicked,
                parent;

            clicked = event.target;
            parent = getParent(clicked);
            if (!parent) {
                return;
            }
            parent.style.background = '#333333';
        }

        function resetBackgroundColor(event) {
            var clicked,
                parent;

            clicked = event.target;
            parent = getParent(clicked);
            if (!parent) {
                return;
            }
            parent.style.background = '';
        }

        function getParent(element) {
            var parent = element;

            if (parent instanceof HTMLLIElement || parent instanceof HTMLImageElement || parent instanceof HTMLHeadingElement) {
                while (parent && parent.className.indexOf('image-container') < 0) {
                    parent = parent.parentNode;
                }
                return parent;
            }
        }
    };
}

module.exports = solve;