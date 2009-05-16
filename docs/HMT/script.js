function highlightTarget() {
		if(location.hash!=""){
			var trElements = document.getElementsByTagName("TR");
			for (var i=0; i<trElements.length; i++) {
				trElements[i].className = trElements[i].className.replace(/highlightAnchor/, "")
				if (trElements[i].id) {
					if (location.hash==("#" + trElements[i].id.replace(/_Region/, ""))) {
						trElements[i].className+=" highlightAnchor";
					}
				}
			}
		}
}

function initialize(){
	highlightTarget();
}