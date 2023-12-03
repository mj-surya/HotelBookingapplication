import { useState ,useEffect} from "react";
import axios from "axios";
import './Rooms.css';

function Rooms({hotel}){
    const [roomList, setRoomList] = useState([]);
    useEffect(() => {
        getRoom();
    }, []);

    const getRoom = () => {
        
        axios.get('http://localhost:5272/api/Room/GetAvailableRooms',{
            params: {
              hotelId : hotel.hotelId,
              checkIn : hotel.checkIn,
              checkOut : hotel.checkOut
            }
          })
          .then((response) => {
            const posts = response.data;
            console.log(posts);
            setRoomList(posts);
        })
        .catch(function (error) {
            alert("Could not get rooms")
            console.log(error);
           
        })
    }
    const book=()=>{

    }


    var CheckRooms = roomList.length>0 ? true : false;
    return(
        <div>
        
            <hr/>
            {CheckRooms?
                <div>
                    {roomList.map((room)=>
                        <figure class="hotel-card">
                        <div class="hotel__hero">
                          <img src={room.picture} alt="Rambo" class="hotel__img"/>
                        </div>
                        <div class="hotel__content">
                          <div class="hotel__title">
                            <h1 class="heading__primary">{room.roomType}</h1>
                          </div>
                          <p class="hotel__city">Capacity: {room.capacity} persons</p>
                          <div class="hotel__rating">
                          <h6>Amenities: </h6>
                                        {(room.amenities).map((str, index) => (
                                            <span key={index}><li><svg xmlns="http://www.w3.org/2000/svg" width="30" height="30" fill="currentColor" class="bi bi-dot" viewBox="0 0 16 16">
                                            <path d="M8 9.5a1.5 1.5 0 1 0 0-3 1.5 1.5 0 0 0 0 3"/>
                                          </svg>{str}</li></span>
                                        ))}
                            </div>
                          <p class="hotel__description">{room.totalRooms} available to book.</p>
                          <button class="btn btn-primary" onClick={()=>book()}>Book Rooms</button>
                        </div>
                        <div class="hotel__price">Price ₹.{room.price}</div>
                      </figure>
                    )}
                </div>
                :
                <div>No Rooms available yet</div>    
            }
        </div>
    )
}

export default Rooms;