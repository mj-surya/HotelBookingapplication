import { useState ,useEffect} from "react";
import axios from "axios";

import './HotelCard.css';

function AdminRooms({hotel}){
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
            setRoomList(posts);
        })
        .catch(function (error) {
            alert(error.response.data);
           
        })
    }
    
    const deleteRoom = (id) => {
      const token = localStorage.getItem('token');
       console.log(id);
       const confirmation = window.confirm("Are you sure you want to delete the room?");
       if(confirmation){
        axios.delete('http://localhost:5272/api/Room/deleterooms', {
        params :{
          id : id
        },
        headers: {
          Authorization: `Bearer ${localStorage.getItem("token")}`,
        },
      })
        .then((response) => {
          alert("Room Deleted");
          getRoom();
        })
        .catch(function (error) {
          alert(error.response ? error.response.data : 'An error occurred');
        }); 
       }
      
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
                    <img src={room.picture} alt="Rambo" class="hotel__img"/>
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
                    <button class="btn btn-danger" onClick={()=>deleteRoom(room.roomId)}>Delete</button>
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

export default AdminRooms;