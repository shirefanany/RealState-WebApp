$(document).ready(function() {

    // Define flickity carousel
    var $gallery = $('.gallery').flickity({
      imagesLoaded: true,
      percentPosition: false,
      wrapAround: true,
      pageDots: false
    });
  
    var flkty = $gallery.data('flickity');
  
    $gallery.on('staticClick', function(event, pointer, cellElement, cellIndex) {
      // Do nothing if cell was not clicked
      if (!cellElement) {
        return;
      }
      // Find image url and use it to tell Fancybox what to target
      var $zoomurl = $(cellElement).find('img').attr('src');
      $.fancybox($zoomurl);
    });
  
  });