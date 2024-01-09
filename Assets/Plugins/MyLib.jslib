mergeInto(LibraryManager.library, {
  GetDeviceLocation: function() {
    if ("geolocation" in navigator) {
      navigator.geolocation.getCurrentPosition(function(position) {
        var location = 'Lat: ' + position.coords.latitude + ', Lon: ' + position.coords.longitude;
        console.log(location);

        // Allocate memory for the string and get a pointer to it
        var bufferSize = lengthBytesUTF8(location) + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(location, buffer, bufferSize);

        // Pass the pointer back to Unity
        SendMessage('LocationReceiver', 'UpdateLocation', buffer);

      });
    } else {
      console.log("Geolocation is not available.");
    }
  }
});