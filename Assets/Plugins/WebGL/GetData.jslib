mergeInto(LibraryManager.library, {
   GetGameData: function (player, score) {
      // Convert bytes to the text
      var convertedName = Pointer_stringify(player);
	  var convertedScore = Pointer_stringify(score);
      // Show a message
      console.log("Name: " + convertedName);
	  console.log("Score: " + convertedScore);
   }
});