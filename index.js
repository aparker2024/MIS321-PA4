//add, delete buttons working. still need to pin
//sort by date
let uniqueID = 1
let exerciseList = []
function handleOnLoad(){
    exerciseList = JSON.parse(localStorage.getItem('exerciseList')) || []
    
    loadExercises()
}

function loadExercises (){
    exerciseList.sort((a,b) => new Date(b.complete) - new Date(a.complete))
    let html =`<div class="row">`

    exerciseList.forEach(function(exercise){
        exercise.id = crypto.randomUUID()
        html += `  
        <div class="card m-4" style="width: 18rem;">
        <img src="${exercise.img}" class="card-img-top" alt="...">
        <div class="card-body">
          <h5 class="card-title">${exercise.title}</h5>
          <p class="card-text">Disance (miles): ${exercise.distance}</p>
          <p class="card-text">Date of Completion: ${exercise.complete}</p>
          <a href="#" class="btn btn-outline m-4" style="color: #800;" id="pinButton-${exercise.id}" onclick="pinExercise(${exercise.id})" >${exercise.pinned ? 'Pinned' : 'Pin'}</a>          
          <a href="#" class="btn btn-outline m-4" style="color: #800;" onclick="deleteExercise('${exercise.title}')">Delete</a>

        </div>
      </div>`
      
    })
    html += "</div>"
    document.getElementById("exercises").innerHTML = html
  
   
}

 
function handleNewCard(){
    let html = `
    <button style="color: #800; background-color: black ;"  disabled>
    
    <h1>New Exercise</h1>
    <form onsubmit="return false";>
        <label for="newTitle">Activity Type:</label><br>
        <input type="text" id="newTitle" name="newTitle"><br>
        <label for="newDistance">Distance (miles):</label><br>
        <input type="text" id="newDistance" name="newDistance"><br>
        <label for="newComplete">Completion Date:</label><br>
        <input type="text" id="newComplete" name="newComplete"><br>
        <button onclick="submitExercise()" class="btn btn-danger">Submit</button>
        
    </form>
        </button>
    `
  document.getElementById('newExercise').innerHTML=html 
  
}


function submitExercise(){  
    let newTitle = document.getElementById('newTitle').value
    let newDistance = document.getElementById('newDistance').value
    let newComplete = document.getElementById('newComplete').value

    let exercise = {
        img: "./Script A2-2.jpg",
        title: newTitle,
        distance: newDistance,
        complete: newComplete,
         
    }
    exerciseList.push(exercise)
    exercise.id = uniqueID++,
   localStorage.setItem('exerciseList', JSON.stringify(exerciseList))

    loadExercises()

    document.getElementById('newTitle').value =''
    document.getElementById('newDistance').value =''
    document.getElementById('newComplete').value =''
    document.getElementById('newExercise').innerHTML = ''
}

function pinExercise(id){
      
    const pinnedExercise = exerciseList.find(exercise =>exercise.id == id )
    
    if(pinnedExercise){
        if(!pinnedExercise.pinned){
            pinnedExercise.pinned = true
            document.getElementById(`pinButton-${id}`).textContent= 'Pinned'
        }
        else{
            pinnedExercise.pinned = false
            document.getElementById(`pinButton-${id}`).textContent= 'Pin'
        }
    }
     localStorage.setItem('exerciseList',JSON.stringify(exerciseList))
    loadExercises()
}

function deleteExercise(title){

    console.log("deleted")   
    exerciseList = exerciseList.filter(exercise => exercise.title != title) 
    localStorage.setItem('exerciseList',JSON.stringify(exerciseList))
    exerciseList.forEach((exercise, index) => {
        exercise.id = index + 1
    })
    loadExercises()
}

