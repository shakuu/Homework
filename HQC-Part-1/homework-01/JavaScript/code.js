var myModule = (function () {
	var NETSCAPE = 'Netscape',
		VISIBILITY_STRINGS = {
			NETSCAPE: {
				VISIBLE: 'show',
				HIDDEN: 'hide'
			},
			OTHER: {
				VISIBLE: 'visible',
				HIDDEN: 'hidden'
			}
		},

		browserName = navigator.appName,
		addScroll = false,
		positionX = 0,
		positionY = 0,

		hideTooltip,
		hideMenu1,
		showMenu1,
		hideMenu2,
		showMenu2;

	if (navigator.userAgent.indexOf('MSIE 5') >= 0 ||
			navigator.userAgent.indexOf('MSIE 6') >= 0) {
		addScroll = true;
	}

	if (browserName === NETSCAPE) {
		document.captureEvents(Event.MOUSEMOVE);
	} else {
		document.onmousemove = onMouseMove;
	}

	function onMouseMove(ev) {
		var TOOLTIP_NAME = 'ToolTip', 
			offsetX = 5,
			toolTip;

		if (browserName === NETSCAPE) {
			positionX = ev.pageX - offsetX;
			positionY = ev.pageY;
		} else {
			positionX = event.x - offsetX;
			positionY = event.y;
		}

		toolTip = document.layers.ToolTip || document.all.ToolTip.style;
		if (toolTip.visibility === VISIBILITY_STRINGS.NETSCAPE.VISIBLE ||
				toolTip.visibility === VISIBILITY_STRINGS.OTHER.VISIBLE) {
			showTooltip(TOOLTIP_NAME);
		}
	}

	function showTooltip(layer) {
		var elementWidth = 120,
			windowWidth,
			offsetPositionX = 150,
			offsetLeft = 10,
			offsetTop = 15;

		if (!layer) {
			return;
		}

		documentWidth = window.innerWidth || document.body.clientWidth;
		positionX = keepElementInVisibleSpace(positionX, elementWidth, documentWidth);

		if (browserName === NETSCAPE) {
			layer.left = positionX + offsetLeft;
			layer.top = positionY + offsetTop;
		} else {
			if (addScroll) {
				positionX = positionX + document.body.scrollLeft;
				positionY = positionY + document.body.scrollTop;
			}

			layer.style.pixelLeft = positionX + offsetLeft;
			layer.style.pixelTop = positionY + offsetTop;
		}

		setLayerVisibility(layer, true);

		function keepElementInVisibleSpace(positionX, elementWidth, documentWidth) {
			if (!documentWidth || positionX + elementWidth > documentWidth) {
				positionX -= offsetPositionX;
			}

			return positionX;
		}
	}

	hideTooltip = function () {
		setLayerVisibility('ToolTip', false);
	};

	hideMenu1 = function () {
		setLayerVisibility('menu1', false);
	};

	showMenu1 = function () {
		setLayerVisibility('menu1', true);
	};

	hideMenu2 = function () {
		setLayerVisibility('menu2', false);
	};

	showMenu2 = function () {
		setLayerVisibility('menu2', true);
	};

	function setLayerVisibility(layer, isVisible) {
		var visibility;

		if (!layer || typeof isVisible !== 'boolean') {
			return;
		}

		if (browserName === NETSCAPE) {
			visibility = isVisible ?
				VISIBILITY_STRINGS.NETSCAPE.VISIBLE : VISIBILITY_STRINGS.NETSCAPE.HIDDEN;
			document.layers[layer].visibility = visibility;
		} else {
			visibility = isVisible ?
				VISIBILITY_STRINGS.OTHER.VISIBLE : VISIBILITY_STRINGS.OTHER.HIDDEN;
			document.all[layer].style.visibility = visibility;
		}
	}
} ());

