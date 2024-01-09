mergeInto(LibraryManager.library, {

  Hello: function () {
    window.alert("Hello, world!");
  },

  HelloString: function (str) {
    window.alert(Pointer_stringify(str));
  },
  
  GetLatestItemID: function () {
	fetch("http://localhost:8080/item/latest")
		.then((response) => response.json())
		.then((json) => console.log(json))
  },
  
  PostItemData: function(endpoint, itemID, itemName, itemType)
  {
  endpoint = Pointer_stringify(endpoint)
	itemID = Pointer_stringify(itemID)
	itemName = Pointer_stringify(itemName)
	itemType = Pointer_stringify(itemType)
	const finalEndpoint = endpoint.concat(itemID)
	fetch(finalEndpoint, {
		method: 'POST',
		headers: {
			'Accept': 'application/json',
			'Content-Type': 'application/json'
		},
		body: JSON.stringify({"itemName": itemName, "type": itemType})
	}).then(response => response.json())
	  .then(response => console.log(JSON.stringify(response)))
  },

  GetSanityItemData: function(callback)
  {
      let PROJECT_ID = "bcvv86pc";
      let DATASET = "items";
      let QUERY = encodeURIComponent('*[_type == "item"]{"modelUrl": model.asset->url,description,price,name}');

      // Compose the URL for your project's endpoint and add the query
      let URL = `https://${PROJECT_ID}.api.sanity.io/v2021-10-21/data/query/${DATASET}?query=${QUERY}`;

      // fetch the content
      fetch(URL)
        .then((res) => res.json())
        .then(({ result }) => {
          if (result.length > 0) {
            var returnStr = JSON.stringify(result);
            var bufferSize = lengthBytesUTF8(returnStr) + 1;
            var buffer = _malloc(bufferSize);
            stringToUTF8(returnStr, buffer, bufferSize);
            Module['dynCall_vi'](callback, buffer);
          }
        })
  },

  PrintFloatArray: function (array, size) {
    for(var i = 0; i < size; i++)
    console.log(HEAPF32[(array >> 2) + size]);
  },

  AddNumbers: function (x, y) {
    return x + y;
  },

  StringReturnValueFunction: function () {
    var returnStr = "bla";
    var buffer = _malloc(lengthBytesUTF8(returnStr) + 1);
    writeStringToMemory(returnStr, buffer);
    return buffer;
  },

  BindWebGLTexture: function (texture) {
    GLctx.bindTexture(GLctx.TEXTURE_2D, GL.textures[texture]);
  },
  
  OpenWindow: function(link) {
         var url = Pointer_stringify(link);
         window.open(url);
     },
});