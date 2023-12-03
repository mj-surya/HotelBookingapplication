import { useState ,useEffect} from "react";
import axios from "axios";
import { useLocation } from "react-router-dom";

function UpdateRoom(){
    const [roomList, setRoomList] = useState([]);

    const location = useLocation(); // Access location state

    useEffect(() => {
      // Extract data from location state
      const { state } = location;
      if (state) {
        const { hotelId: receivedHotelId, checkIn: receivedCheckIn, checkOut: receivedCheckOut } = state;
        getRoom(receivedHotelId,receivedCheckIn,receivedCheckOut);
        // Now you have the hotelId, checkIn, and checkOut from the navigation state
        // Use this data to fetch rooms or perform other actions
      }
    }, [location]);
    const getRoom = (hotelId,checkIn,checkOut)=>{
        //event.preventDefault();
        axios.get('http://localhost:5272/api/Room/GetAvailableRooms',{
            params: {
              hotelId : hotelId,
              checkIn : checkIn,
              checkOut : checkOut
            }
          })
          .then((response) => {
            const posts = response.data;
            console.log(posts);
            setRoomList(posts);
        })
        .catch(function (error) {
            alert("Could not get hotel")
            console.log(error);
           
        })
    }

    const updateRoom =()=>
    var CheckRooms = roomList.length>0 ? true : false;
    return(
        <div>
        
            <hr/>
            {CheckRooms?
                <div>
                    {roomList.map((room)=>
                        <div key={room} class="card">
                            <div class="row">
                                <div class="col-3">
                                    <img class="card-img cardimg" src={room.picture} alt="Card image cap"/>
                                </div>
                                <div class="col-6">
                                    <div class="card-body">
                                        <h5 class="card-title">{room.roomType}</h5>
                                        <h6 class="card-title">{room.capacity}</h6>
                                        <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
                                    </div>
                                </div>
                                < div class="col-3">
                                    <h5>Price</h5>
                                    <button onClick={updateRoom}>Update</button>
                                    <button>Delete</button>
                                </div>
                            </div>     
                        </div>
                    )}
                </div>
                :
                <div>No Rooms available yet</div>    
            }
        </div>
    )
}

export default UpdateRoom;