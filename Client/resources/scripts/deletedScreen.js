function getDeleted(){
    const allExerciseAPIURL = "http://localhost:5047/api/Exercise";

    // fetch exercises from API
    fetch(allExerciseAPIURL).then(function(response){
        console.log(response);
       
        return response.json();
    }).then(function(json){ 
        let html =`<div class="row">`
        json.forEach((exerciseList) => {
            console.log(exerciseList.deleted)
            
            if(exerciseList.deleted == "Yes")
            {
            html += `  
        <div class="card m-4" style="width: 18rem;">
        <img src="./img/Script A2-2.jpg" class="card-img-top" alt="...">
        <div class="card-body">
          <h5 class="card-title" id="newAcTy">${exerciseList.activityType}</h5>
          <p class="card-text" id="newDIM">Disance (miles): ${exerciseList.distanceMiles}</p>
          <p class="card-text" id="newDOC">Date of Completion: ${exerciseList.completionDate}</p>
          <a href="#" class="btn btn-outline m-4" style="color: #800;" id="newPinButton"></a>          
          <a href="#" class="btn btn-outline m-4" style="color: #800;" id="newDEL" onclick="updateExercise('${exerciseList.exerciseID}') ">Delete</a>
            
        </div>
      </div>`
     }
        }); 

            
            
        html += "</div>"
        
        document.getElementById("deletedExercises").innerHTML = html;
    }).catch(function(error){
        console.log(error)
    }) 
}

function updateExercise(exerciseID,exerciseList) //put
{
    debugger
    const activity = document.getElementById('newAcTy').textContent;
    const distant = document.getElementById('newDIM').textContent;
    const complete = document.getElementById('newDOC').textContent;
    const piiinnn = document.getElementById('newPinButton').textContent;
    const dele = "No";
    const updateExerciseAPIURL = `http://localhost:5047/api/Exercise/${exerciseID}`;
    console.log(updateExerciseAPIURL)
    console.log(exerciseID)
  
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
            Pinned: piiinnn,
            Deleted: dele
            
        })
      
            }).then((response)=>{
                console.log(response)
                getDeleted();
            })             
}

