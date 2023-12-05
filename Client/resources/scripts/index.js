function getExercise(){  //Get
    const allExerciseAPIURL = "http://localhost:5047/api/Exercise";

    
    fetch(allExerciseAPIURL).then(function(response){
        console.log(response);
       
        return response.json();
    }).then(function(json){ 
        let html =`<div class="row">`
        json.forEach((exerciseList) => {
            console.log(exerciseList)
        
        if(exerciseList.deleted == "No"){
            html += `  
        <div class="card m-4" style="width: 18rem;">
        <img src="./img/Script A2-2.jpg" class="card-img-top" alt="...">
        <div class="card-body">
          <h5 class="card-title" id="AcTy">${exerciseList.activityType}</h5>
          <p class="card-text" id="DIM">Disance (miles): ${exerciseList.distanceMiles}</p>
          <p class="card-text" id="DOC">Date of Completion: ${exerciseList.completionDate}</p>
          <a href="#" class="btn btn-outline m-4" style="color: #800;" id="pinButton-${exerciseList.exerciseID}" onclick="updateExercise('${exerciseList.exerciseID}', '${exerciseList}')" >Pin</a>          
          <a href="#" class="btn btn-outline m-4" style="color: #800;" id="DEL" onclick="deleteExercise('${exerciseList.exerciseID}')">Delete</a>
            
        </div>
      </div>`
        }
            
        }); 

        
        
        html += "</div>"
        
        document.getElementById("exercises").innerHTML = html;
    }).catch(function(error){
        console.log(error)
    }) 
}

function postExercise(){  //post
    const postExerciseAPIURL = "http://localhost:5047/api/Exercise";
    
    const activity = document.getElementById('newActivity').value;
    console.log(activity)
    const distances = document.getElementById('newDistance').value;
    const completions = document.getElementById('newComplete').value;
    const pin = false
    const del = "No"

    const newExercise = {
        activityType: activity,
            distanceMiles: distances,
            completionDate: completions,
            Pinned: pin,
            Deleted: del
    }
    console.log(newExercise)
    
    fetch(postExerciseAPIURL,{
        method: "POST",
        headers: {
            "Accept": 'application/json',
            "Content-Type": 'application/json',
        },
        body: JSON.stringify(newExercise)
    }).then((response)=>{
        console.log(response)
        getExercise();
    })
}

//figure out how to remove it.. updates in data base 
function deleteExercise(exerciseID){ //delte

    const deleteExerciseAPIURL = `http://localhost:5047/api/Exercise/${exerciseID}`;
    console.log(exerciseID);
    console.log(deleteExerciseAPIURL);
    
    fetch(deleteExerciseAPIURL,{
        method: "DELETE"
            }).then((response)=>{
                console.log(response)
                getExercise();
            })    
}

//not functional
function updateExercise(exerciseID, exerciseList) //put
{
    debugger
    const activity = document.getElementById('AcTy').innerHTML;
    const distant = document.getElementById('DIM').innerHTML;
    const complete = document.getElementById('DOC').innerHTML;
    const pinner = "yes";
    const dele = document.getElementById('DEL').innerHTML;
    const updateExerciseAPIURL = `http://localhost:5047/api/Exercise/${exerciseID}`;
    console.log(updateExerciseAPIURL)
    debugger
    fetch(updateExerciseAPIURL,{
        method: "PUT",
        headers: {
            "Accept": 'application/json',
            "Content-Type": 'application/json',
        },
        body: JSON.stringify({
            activityType: activity,
            distanceMiles: -1,
            completionDate: complete,
            Pinned: pinner,
            Deleted: dele

        })
            }).then((response)=>{
                console.log(response)
                getExercise();
            })             
}


function handleNewCard(){
    
    let html = `
    <button style="color: #800; background-color: black ;"  disabled>
    
    <h1>New Exercise</h1>
    <form onsubmit="return false";>
        <label for="newActivity">Activity Type:</label><br>
        <input type="text" id="newActivity" name="newActivity"><br>
        <label for="newDistance">Distance (miles):</label><br>
        <input type="text" id="newDistance" name="newDistance"><br>
        <label for="newComplete">Completion Date:</label><br>
        <input type="text" id="newComplete" name="newComplete"><br>
        <input type="submit" value="Submit" onclick="postExercise()">
        
    </form>
        </button>
    `
  document.getElementById('newExercise').innerHTML=html

}
