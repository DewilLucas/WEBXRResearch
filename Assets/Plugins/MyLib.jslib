mergeInto(LibraryManager.library, {
  GetDeviceLocation: function() {
     var previousLocation = null;
     function updateLocation() {
       if ("geolocation" in navigator) {
        navigator.geolocation.getCurrentPosition(
          function(position) {
            var location = {
              latitude: position.coords.latitude,
              longitude: position.coords.longitude,
              accuracy: position.coords.accuracy
            };

            // Allocate memory for the string and get a pointer to it
            var locationString = JSON.stringify(location);
            if (locationString !== previousLocation) {
              //console.log(locationString);
              var bufferSize = lengthBytesUTF8(locationString) + 1;
              var buffer = _malloc(bufferSize);
              stringToUTF8(locationString, buffer, bufferSize);

              // Pass the pointer back to Unity
              SendMessage('LocationReceiver', 'UpdateLocation', buffer);

              // Free the allocated memory
              _free(buffer);

              previousLocation = locationString;
            }
          },
          function(error) {
            console.error("Error getting location:", error.message);
          },
          {
            enableHighAccuracy: true, // Request high accuracy
            timeout: 1000, // Maximum time (in milliseconds) allowed for obtaining the location
            maximumAge: 0 // Discard any cached position and force a new one
          }
        );
      } else {
        console.log("Geolocation is not available.");
      }
    }

    // Call updateLocation immediately and then every 1000 milliseconds (1 second)
    updateLocation();
    setInterval(updateLocation, 1000);
  }
});

