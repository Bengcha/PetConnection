function getPetApi(){
	
	this.getPet = function( ) {
		var key = "6d2501374548411c2b0684ee900e7c62"
		var url2 = "http://api.petfinder.com/my.method?key=" + key + "&arg1=foo&token=67890&sig=abcdef" ;
		
	$("#get-music-button").text("loading?");
	$.getJSON("http://api.petfinder.com/my.method?format=json&key=" + key +"&callback=?")
  .done(function(petApiData) { alert('Data retrieved!');
getPets();  })
  .error(function(err) { alert('Error retrieving data!'); 
});
	}
}


function getPets()
{
	var key = "6d2501374548411c2b0684ee900e7c62"
		var url2 = "http://api.petfinder.com/my.method?key=" + key + "&arg1=foo&token=67890&sig=abcdef" ;
var petAPI = url2;
var id = document.getElementById("userInput").value;
var url = petAPI + id;

$.ajax({
  url: url,
  method: 'get',
  data: {term:id},
  dataType: 'jsonp',
  success: function(data) {
   new showMatch(data);
    }
  });
}
	
	function showMatch(data){
	  
	  
	  for(var i =0;i<10;i++)
  {
	  var typing = "audio/mpeg";
    $('#tables').append(
      
     
	
	"<tr>" +
    "<td>" + " " + data.results[i].artistName + "</td>" +
    "<td>" + " " + data.results[i].trackName + "</td>" +
    "<td>" + " " + data.results[i].primaryGenreName + "</td>" +
	"<td>" + "<img src = "+data.results[i].artworkUrl100 + ">" + "</td>" +
	
	"<td>" + "<audio controls> "+"<source src= " + data.results[i].previewUrl + " type =" + typing + "> " +  "</audio> " + "</td>" +
  "</tr>"
  
    );
    
  };
	  
  }
  
  
  
 function testThis(shelID){
$(document).ready(function(){
	
	var key = "6d2501374548411c2b0684ee900e7c62";
	console.log(shelID);
    var url = "http://api.petfinder.com/shelter.getPets?key="+ key + "&id="+ shelID + "&output=full&format=json&count=25";
    $.ajax({
        type : 'GET',
        data : {},
        url : url+'&callback=?' ,
        dataType: 'json',
        success : function(data) {              
           $('#zipps').empty();
            var result = '';

            var petfinder = data.petfinder;
            
			
			if(petfinder != undefined){
		for(var i =0;i<petfinder.pets.pet.length;i++){
			$('#tables').append(
			"<tr>" +
			"<td>" + petfinder.pets.pet[i].name["$t"]+ "</td>"+
			"<td>" + "<img src=" + petfinder.pets.pet[i].media.photos.photo[2]["$t"] + "></img>" +"</td>"+
			"</tr>"
			
		);}
            }
			else{}
            console.log(petfinder);
			
        },
        error : function(request,error)
        {
            alert("Request: "+JSON.stringify(request));
        }
    });
});

 }
 

 
 function grabShelter(){
	 
	  var zip = document.getElementById("userInput2").value;
		
	var key = "6d2501374548411c2b0684ee900e7c62";
    var url = "http://api.petfinder.com/shelter.find?key="+ key +  "&location=" + zip  +  "&format=json";
    $.ajax({
        type : 'GET',
        data : {},
        url : url+'&callback=?' ,
        dataType: 'json',
        success : function(data) { loggingZip(data);}
	})
 }

function loggingZip(data){
           $('#zipps').empty();
		   $('#tables').empty();
            var result = '';
			var shelt = data.petfinder.shelters.shelter;
            var petfinder = data.petfinder;
             for(var i =0;i<data.petfinder.shelters.shelter.length;i++){
				 
			$('#zipps').append(
			
			"<tr>" +
			"<td>" + shelt[i].address1["$t"] + "</td>"+
			"<td>" + shelt[i].city["$t"] + "</td>"+
			"<td>" + shelt[i].id["$t"] + "</td>"+
			"<td>" + shelt[i].name["$t"] + "</td>"+
			"<td>" + shelt[i].zip["$t"] + "</td>"+
			"<td>" + "<button onclick=\"testThis('" + shelt[i].id["$t"] + "')\" id='search' class='btn btn-default'>Search</button>" +
	"</tr>"
			
			
			);
			 }
            console.log(data);
        }
        
   
	 


	