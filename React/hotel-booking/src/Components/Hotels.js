import { useEffect, useState } from "react";
import axios from "axios";
import './HotelCard.css';
import { useNavigate } from "react-router";
import ViewHotel from "./ViewHotel";


function Hotels(){
    const [HotelList,setHotelList]=useState([]);
    const [search,setSearch] = useState("");
    const [checkIn,setCheckIn] = useState("");
    const [checkOut,setCheckOut] = useState("");
    const navigate = useNavigate();
    const[searchList,setSearchList]=useState(["Coimbatore","Tirupur","Chennai","Bangalore"]);
    const[filters,setFilter]=useState([]);

    useEffect(() => {
        filter(search);
    }, [search]);

    const filter = (search) => {
        const filteredList = searchList.filter((item) =>
            item.toLowerCase().includes(search.toLowerCase())
        );
        setFilter(filteredList);
    };
    
    var getHotels = (event)=>{
        event.preventDefault();
        axios.get('http://localhost:5272/api/Hotel',{
            params: {
              city : search
            }
          })
          .then(async(response) => {
            const posts = await response.data;
            setHotelList(posts);
        })
        .catch(function (error) {
            alert(error.response.data);
        })
    }

    const shorten = (para)=>{
        return para.slice(0,200)+'...';
    }
    
    var checkHotels = HotelList.length>0?true:false;

    const view = (hotel)=>{
        navigate('/ViewHotel',{ state: { hotel,checkIn,checkOut } });
    }
    const currentDate = new Date().toISOString().split('T')[0];
    
    return(
        <div className="hotel" >
            <div>
                <form class="form-size" onSubmit={getHotels}>
                    <div class="row">
                    <div className="col input-size">
                        <span className="date-placeholder">Destination</span>
                        <input
                            type="text"
                            className="form-control input"
                            list="searchOptions"
                            placeholder="Search"
                            value={search}
                            onChange={(e) => {
                                setSearch(e.target.value);
                                filter(e.target.value);}}/>
                        <datalist id="searchOptions">
                            {filters.map((filter) => (<option key={filter} value={filter} />))}
                        </datalist>
                    </div>
                        <div class="col input-size">
                            <span className="date-placeholder">Check-In</span>
                            <input id="pchechIn" required type="date" class="form-control input" placeholder="Check-In" value={checkIn} onChange={(e)=>{setCheckIn(e.target.value)}} min={currentDate}/>
                            
                        </div>
                        <div class="col input-size">
                        <span className="date-placeholder">Check-Out</span>
                            <input id="pcheckOut" required type="date" class="form-control input" placeholder="Check-Out" value={checkOut} onChange={(e)=>{setCheckOut(e.target.value)}} min={checkIn}/>
                        </div>
                        <div class="col down">
                        <button className="btn btn-primary button btn-size">Search</button>
                        </div>
                    </div>
                </form>
                <hr/>
            </div>
            <div>
                {checkHotels?
                    <div>
                        {HotelList.map((hotel)=>
                            <figure class="hotel-card row">
                            <div class="hotel__hero col">
                              <img src={hotel.image} alt="Rambo" class="hotel__img"/>
                            </div>
                            <div class="hotel__content col">
                              <div class="hotel__title">
                                <h1 class="heading__primary">{hotel.hotelName}</h1>
                              </div>
                              <p class="hotel__city"><svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-geo-fill" viewBox="0 0 16 16">
                                <path fill-rule="evenodd" d="M4 4a4 4 0 1 1 4.5 3.969V13.5a.5.5 0 0 1-1 0V7.97A4 4 0 0 1 4 3.999zm2.493 8.574a.5.5 0 0 1-.411.575c-.712.118-1.28.295-1.655.493a1.319 1.319 0 0 0-.37.265.301.301 0 0 0-.057.09V14l.002.008a.147.147 0 0 0 .016.033.617.617 0 0 0 .145.15c.165.13.435.27.813.395.751.25 1.82.414 3.024.414s2.273-.163 3.024-.414c.378-.126.648-.265.813-.395a.619.619 0 0 0 .146-.15.148.148 0 0 0 .015-.033L12 14v-.004a.301.301 0 0 0-.057-.09 1.318 1.318 0 0 0-.37-.264c-.376-.198-.943-.375-1.655-.493a.5.5 0 1 1 .164-.986c.77.127 1.452.328 1.957.594C12.5 13 13 13.4 13 14c0 .426-.26.752-.544.977-.29.228-.68.413-1.116.558-.878.293-2.059.465-3.34.465-1.281 0-2.462-.172-3.34-.465-.436-.145-.826-.33-1.116-.558C3.26 14.752 3 14.426 3 14c0-.599.5-1 .961-1.243.505-.266 1.187-.467 1.957-.594a.5.5 0 0 1 .575.411"/>
                                </svg>&nbsp; {hotel.city}</p>
                              <div class="hotel__rating">
                                    <span>Rating:  </span>
                                    {[1, 2, 3, 4, 5].map((star) => (
                                    <span
                                        key={star}
                                        value ={hotel.avgRating}
                                        style={{
                                        cursor: 'pointer',
                                        color: star <= hotel.avgRating ? 'gold' : 'gray',
                                        }}>
                                        &#9733; 
                                    </span>
                                    ))}
                                </div>
                              <p class="hotel__description">{shorten(hotel.description)}</p>
                              <button class="btn btn-primary" onClick={()=>view(hotel)}>View Rooms</button>
                              
                            </div>
                            <div class="hotel__price">Starts from ₹.{hotel.startingPrice}</div>
                          </figure>
                        )}
                    </div>
                    :
                    <div class="mid">No Hotels available yet</div>    
                }
            </div>
            
        </div>
        

    )
}

export default Hotels;