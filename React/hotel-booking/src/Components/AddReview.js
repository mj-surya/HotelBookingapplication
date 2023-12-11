import React, { useState } from 'react';
import axios from 'axios';
import './AddReview.css'

function AddReview({id,oncompleted}){
    const [rating, setRating] = useState(0);
    const [review, setReview] = useState("");

  const handleStarClick = (selectedRating) => {
    setRating(selectedRating);
  };

  const addReview=(event)=>{
    event.preventDefault();
    const reviewDTO = {
        hotelId : id,
        userId : localStorage.getItem("id"),
        reviews : review,
        rating : rating
    }
    console.log(reviewDTO);
    axios.post("http://localhost:5272/api/Review/AddReview",reviewDTO,{headers: {
      Authorization: `Bearer ${localStorage.getItem('token')}`,
    }})
    .then((userData)=>{
        alert("Review added");
        oncompleted();
    })
    .catch((err)=>{
        alert(err.response.data);
    })
   
}

  return (
    <div class="addreview card">
      <textarea type="text" placeholder="review" className="form-control" value={review} onChange={(e)=>{setReview(e.target.value)}}/>
        <div>
            <span>Rating:  </span>
            {[1, 2, 3, 4, 5].map((star) => (
            <span
                key={star}
                onClick={() => handleStarClick(star)}
                style={{
                cursor: 'pointer',
                color: star <= rating ? 'gold' : 'gray',
                }}>
                &#9733; 
            </span>
            ))}
        </div>
        <button className="btn btn-primary button" onClick={addReview}>Add Review</button>
    </div>
  );
}

export default AddReview;