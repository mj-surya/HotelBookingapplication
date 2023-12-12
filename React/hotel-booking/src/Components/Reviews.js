import { useEffect, useState } from "react";
import axios from "axios";
import './Reviews.css';

function Reviews({id}){
    const[reviewList, setReviewList]=useState([]);
    var getReviews = ()=>{
        axios.get('http://localhost:5272/api/review/getreview',{
            params: {
              hotelId : id
            }
          })
          .then((response) => {
            const posts = response.data;
            setReviewList(posts);
        })
        .catch((err)=>{
        })
       
    }

    useEffect(()=>{
        getReviews();
    },[]);
    var checkReviews = reviewList.length>0?true:false;
    return(
        <div class="review">
            
            {checkReviews?
            <div>
                {reviewList.map((review)=>
                    <div key={review} class="card reviews">
                        <div class="row">
                            <div class="col">
                            <h5 class="card-title">{review.userId}</h5>
                            <p class="card-text">{review.date}</p>
                            </div>
                            <div class="col">
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
                <div>No Reviews available yet</div>
            }
        </div>
        

    )
}

export default Reviews;

