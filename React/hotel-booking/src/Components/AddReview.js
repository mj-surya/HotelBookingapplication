import React, { useState } from 'react';
import axios from 'axios';

function AddReview(){
    const [rating, setRating] = useState(0);
    const [userId, setUserId] = useState("");
    const [hotelId, setHotelId] = useState(0);
    const [review, setReview] = useState("");

  const handleStarClick = (selectedRating) => {
    setRating(selectedRating);
  };

  const addReview=(event)=>{
    event.preventDefault();
    const reviewDTO = {
        hotelId : hotelId,
        userId : userId,
        reviews : review,
        rating : rating
    }
    console.log(reviewDTO);
    axios.post("http://localhost:5272/api/Review/AddReview",reviewDTO)
    .then((userData)=>{
        console.log(userData)
    })
    .catch((err)=>{
        console.log(err)
    })
   
}

  return (
    <div>
        <input type="text" placeholder="UserId" className="form-control" value={userId} onChange={(e)=>{setUserId(e.target.value)}}/>
        <input type="text" placeholder="HotelId" className="form-control" value={hotelId} onChange={(e)=>{setHotelId(e.target.value)}}/>
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
        <textarea type="text" placeholder="review" className="form-control" value={review} onChange={(e)=>{setReview(e.target.value)}}/>
        <button className="btn btn-primary button" onClick={addReview}>Add Review</button>
    </div>
  );
}

export default AddReview;