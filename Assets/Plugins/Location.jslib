mergeInto(LibraryManager.library, {
  RegisterFunction: function(funcName) {
    // Convert the function name to a string
    var funcNameStr = Pointer_stringify(funcName);

    // Add the function to the library
    this[funcNameStr] = Module.cwrap(funcNameStr, null, ['string', 'string']);
  }
});


mergeInto(LibraryManager.library, {
  GetLocation: function() {
    if (navigator.geolocation) {
      navigator.geolocation.getCurrentPosition(function(position) {
        var lat = position.coords.latitude;
        var lon = position.coords.longitude;
        // Convert the latitude and longitude to strings
        var latStr = allocate(intArrayFromString(lat.toString()), 'i8', ALLOC_NORMAL);
        var lonStr = allocate(intArrayFromString(lon.toString()), 'i8', ALLOC_NORMAL);
        console.log("latStr: "+latStr+" lonStr: "+lonStr);
        // Call the Unity function
        ReceiveLocation(latStr, lonStr);
      });
    } else {
      console.log("Geolocation is not supported by this browser.");
    }
  }
});
