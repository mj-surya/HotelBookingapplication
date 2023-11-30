import { useState } from "react";
import axios from "axios";


function Reviews(){
    const[reviewList, setReviewList]=useState([])
    const hotelId = 1;
    var getReviews = (event)=>{
        event.preventDefault();
        axios.get('http://localhost:5272/api/review/getreview',{
            params: {
              hotelId : hotelId
            }
          })
          .then((response) => {
            const posts = response.data;
            console.log(posts);
            setReviewList(posts);
        })
        .catch(function (error) {
            console.log(error);
        })
    }

    var checkReviews = reviewList.length>0?true:false;
    return(
        <div>
            <button onClick={getReviews}>Get Reviews</button>
            {checkReviews?
            <div>
                {reviewList.map((review)=>
                    <div key={review} class="card">
                        <div class="row">
                            <div class="col-3">
                            <h5 class="card-title">{review.userId}</h5>
                            <p class="card-text">{review.date}</p>
                            </div>
                            <div class="col-6">
                                <div class="card-body">
                                <div>
                                    <span>Rating:  </span>
                                    {[1, 2, 3, 4, 5].map((star) => (
                                    <span
                                        key={star}
                                        value ={review.rating}
                                        style={{
                                        cursor: 'pointer',
                                        color: star <= review.rating ? 'gold' : 'gray',
                                        }}>
                                        &#9733; 
                                    </span>
                                    ))}
                                </div>
                                    <p class="card-text">{review.reviews}</p>
                                </div>
                            </div>
                        </div>
                    </div>
                )}
                </div>
                :
                <div>No Hotels available yet</div>
            }
        </div>
        

    )
}

export default Reviews;