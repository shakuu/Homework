/* globals module */
function solve() {
    return function (selector, items) {
        var container = selector,
            fragment,
            length, i,

            imageList,
            imageListText,
            imageListInput,

            imageContainerTemplate,
            imageContainerText,
            imageContainerImage,
            allImageContainers,

            imagePreviewContainer,
            imagePreviewText,
            imagePreviewImage;

        if (typeof container === 'string') {
            container = document.querySelector(container);
        } else if (container instanceof HTMLElement) {

        } else {
            throw new Error();
        }

        // imageContainerTemplate
        imageContainerTemplate = document.createElement('li');
        imageContainerTemplate.className += 'image-container';
        imageContainerTemplate.style.padding = '10px';

        imageContainerText = document.createElement('strong');
        imageContainerText.style.display = 'block';
        imageContainerText.style.textAlign = 'center';

        imageContainerImage = document.createElement('img');
        imageContainerImage.style.width = '200px';

        imageContainerTemplate.appendChild(imageContainerText);
        imageContainerTemplate.appendChild(imageContainerImage);

        // ImageList
        imageListText = document.createElement('p');
        imageListText.innerHTML = 'Filter';
        imageListText.style.display = 'block';
        imageListText.style.textAlign = 'center';

        imageListInput = document.createElement('input');
        imageListInput.clasName = 'filte-images';

        imageList = document.createElement('ul');
        imageList.className = 'image-list';
        imageList.style.listStyle = 'none';
        imageList.style.float = 'right';
        imageList.style.clear = 'right';
        imageList.style.height = '400px';
        imageList.style.overflowY = 'scroll';

        imageList.appendChild(imageListText);
        imageList.appendChild(imageListInput);
        container.appendChild(imageList);

        imageList.addEventListener('click', onImageListClick);
        imageList.addEventListener('mouseover', onMoustEnterChangeBackgroundColor, true);
        imageList.addEventListener('mouseout', onMouseOutRevertBackgroundColor, true);
        // imageListInput.addEventListener('input', filterImageContainers);

        // Populate the List
        length = items.length;
        fragment = document.createDocumentFragment();
        for (i = 0; i < length; i += 1) {
            imageContainerText.innerHTML = items[i].title;
            imageContainerImage.src = items[i].url;

            fragment.appendChild(imageContainerTemplate.cloneNode(true));
        }
        imageList.appendChild(fragment);
        allImageContainers = document.getElementsByClassName('image-container');

        // Create ImagePreview
        imagePreviewContainer = document.createElement('div');
        imagePreviewContainer.style.float = 'left';
        imagePreviewContainer.style.width = '400px';

        imagePreviewText = document.createElement('h1');
        imagePreviewText.style.textAlign = 'center';

        imagePreviewImage = document.createElement('img');
        imagePreviewImage.style.width = '400px';

        imagePreviewContainer.appendChild(imagePreviewText);
        imagePreviewContainer.appendChild(imagePreviewImage);

        container.appendChild(imagePreviewContainer);
        container.style.width = '960px';

        // Set initial Value to ImagePreview
        imagePreviewText.innerHTML = allImageContainers[0].querySelector('strong').innerHTML;
        imagePreviewImage.src = allImageContainers[0].querySelector('img').src;

        // EVENTS
        function onImageListClick(event) {
            var clicked = event.target,
                parent;

            parent = findParentImageContainer(clicked);
            if (!parent) {
                return;
            }

            imagePreviewText.innerHTML = parent.querySelector('strong').innerHTML;
            imagePreviewImage.src = parent.querySelector('img').src;
        }

        function onMouseOutRevertBackgroundColor(event) {
            var clicked = event.target,
                parent;

            parent = findParentImageContainer(clicked);
            if (!parent) {
                return;
            }

            parent.style.backgroundColor = '';
        }

        function onMoustEnterChangeBackgroundColor(event) {
            var clicked = event.target,
                parent;
                
            parent = findParentImageContainer(clicked);
            if (!parent) {
                return;
            }

            parent.style.backgroundColor = '#E6E6E6';
        }

        function findParentImageContainer(target) {
            var parent = target;
            while (parent && parent.className.indexOf('image-container') < 0) {
                parent = parent.parentNode;
            }
            return parent;
        }
    };
}

module.exports = solve;