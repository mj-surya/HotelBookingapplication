import { useState ,useEffect} from "react";
import axios from "axios";
import './Rooms.css';
import Popup from "reactjs-popup";
import AddBooking from './AddBooking.js';
import Login from './Login.js';

function Rooms({hotel}){
    const [roomList, setRoomList] = useState([]);
    const [isPopupOpen, setPopupOpen] = useState(false);
    const [isLoginOpen, setLoginOpen] = useState(false);
    const [selectedRoom, setSelectedRoom] = useState(null);
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
            setRoomList(posts);
        })
        .catch((err)=>{
        })
    }
    const book = (room) => {
      setSelectedRoom(room);
      if(localStorage.getItem("token")){
        setPopupOpen(true);
      }else{
        setLoginOpen(!isLoginOpen);
      }
    }
    const handleBookingComplete = () => {
      setPopupOpen(false); 
      getRoom();
    };


    var CheckRooms = roomList.length>0 ? true : false;
    return(
        <div>
        
            <hr/>
            {CheckRooms?
                <div>
                    {roomList.map((room)=>
                        <figure class="hotel-card row">
                        <div class="hotel__hero col">
                          <img src={room.picture} class="hotel__img"/>
                        </div>
                        <div class="hotel__content col">
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
                          <button class="btn btn-primary" onClick={()=>book(room)}>Book Rooms</button>
                        </div>
                        <div class="hotel__price ">Price ₹.{room.price}</div>
                      </figure>
                    )}
                </div>
                :
                <div>No Rooms available yet</div>    
            }
              <Popup open={isPopupOpen} closeOnDocumentClick onClose={() => setPopupOpen(false)} overlayStyle={{ background: 'rgba(0, 0, 0, 0.6)' }} // Optional: Set the overlay background color
  contentStyle={{ background: 'transparent', padding: 0 }}
  className={isPopupOpen ? 'blur-background' : 'blr'}>
            <div onClick={(e)=>e.stopPropagation()}>
            <AddBooking room={selectedRoom} hotel={hotel} onBookingComplete={handleBookingComplete} />
            </div>
                
              </Popup>
              <Popup open={isLoginOpen} closeOnDocumentClick onClose={()=>setLoginOpen(!isLoginOpen)} overlayStyle={{ background: 'rgba(0, 0, 0, 0.6)' }} // Optional: Set the overlay background color
  contentStyle={{ background: 'transparent', padding: 0 }}
  className={isLoginOpen ? 'blur-background' : 'blr'}>
                  <Login />
              </Popup>
            
        </div>
    )
}

export default Rooms;