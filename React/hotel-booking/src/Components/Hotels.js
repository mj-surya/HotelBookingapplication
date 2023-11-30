import { useState } from "react";
import axios from "axios";
import './HotelCard.css';
import Rooms from "./Rooms";
import { Navigate } from "react-router";
import { useNavigate } from "react-router";


function Hotels(){
    const [HotelList,setHotelList]=useState([]);
    const [search,setSearch] = useState("");
    const [checkIn,setCheckIn] = useState("");
    const [checkOut,setCheckOut] = useState("");
    const navigate = useNavigate();

    var getHotels = (event)=>{
        event.preventDefault();
        axios.get('http://localhost:5272/api/Hotel',{
            params: {
              city : search
            }
          })
          .then((response) => {
            const posts = response.data;
            console.log(posts);
            setHotelList(posts);
        })
        .catch(function (error) {
            console.log(error);
        })
    }

    
    var checkHotels = HotelList.length>0?true:false;

    const view = (hotelId)=>{
    navigate("/GetRoom", { state: { hotelId, checkIn, checkOut } }); 
    }
    
    return(
        <div className="hotels mrg" >
            <form>
                <div class="row">
                    <div class="col">
                        <input id="psearch" type="text" class="form-control" placeholder="Search" value={search} onChange={(e)=>{setSearch(e.target.value)}}/>
                    </div>
                    <div class="col">
                        <input id="pchechIn" type="text" class="form-control" placeholder="Check-In" value={checkIn} onChange={(e)=>{setCheckIn(e.target.value)}}/>
                    </div>
                    <div class="col">
                        <input id="pcheckOut" type="text" class="form-control" placeholder="Check-Out" value={checkOut} onChange={(e)=>{setCheckOut(e.target.value)}}/>
                    </div>
                    <div class="col">
                    <button className="btn btn-primary button" onClick={getHotels}>Search</button>
                    </div>
                </div>
            </form>
            <hr/>
            {checkHotels?
                <div>
                    {HotelList.map((hotel)=>
                        <div key={hotel} class="card">
                            <div class="row">
                                <div class="col-3">
                                    <img class="card-img cardimg" src={hotel.image} alt="Card image cap"/>
                                </div>
                                <div class="col-6">
                                    <div class="card-body">
                                        <h5 class="card-title">{hotel.hotelName}</h5>
                                        <h6 class="card-title">{hotel.city}</h6>
                                        <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
                                    </div>
                                </div>
                                < div class="col-3">
                                    <h5>Price</h5>
                                    <button onClick={()=>view(hotel.hotelId)}>View</button>
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

export default Hotels;