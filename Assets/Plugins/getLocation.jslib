mergeInto(LibraryManager.library, {
    GetCurrentUrl: function () {
        var sentUrl = false; // Flag to track whether the URL has been sent

        var previousLocation = null;
        function GetLocation() {
        if (!sentUrl) {
            var currentUrl = window.location.href;
            // params
            // Extract parameters from the URL using URLSearchParams
            var urlSearchParams = new URLSearchParams(window.location.search);
            var parameters = {};

            urlSearchParams.forEach(function (value, key) {
                    parameters[key] = value;
            });

            var data = {
                URL: currentUrl,
                Parameters: parameters
            };

            console.log("Sending URL to Unity: " + currentUrl);
            
            var locationString = JSON.stringify(data);
            if (locationString !== previousLocation) {
              //console.log(locationString);
              var bufferSize = lengthBytesUTF8(locationString) + 1;
              var buffer = _malloc(bufferSize);
              stringToUTF8(locationString, buffer, bufferSize);

              // Pass the pointer back to Unity
              SendMessage('TestReciever', 'UpdateLocationQR', buffer);

              // Free the allocated memory
              _free(buffer);

              previousLocation = locationString;
              sentUrl = true;
            }
        }
        
        }
        GetLocation();
        setInterval(GetLocation, 10000);
    }
    
});