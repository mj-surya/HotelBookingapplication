import './ViewHotel.css';
import AdminRooms from './AdminRooms.js';
import Reviews from './Reviews.js';
import { useEffect,useState} from 'react';
import axios from "axios";

function ViewAdminHotel() {
  const [checkIn, setCheckIn] = useState("2023-11-12");
  const [checkOut, setCheckOut] = useState("2023-11-13");
  const [hotel, setHotel] = useState({});
  const [hotelId, setHotelId] = useState();
  const [reviewsVisible, setReviewsVisible] = useState(false);

  useEffect(()=>{
    axios.get('http://localhost:5272/api/hotel/getbyid',{
        params:{
            id:localStorage.getItem('id')
        }
    })
    .then((response)=>{
        const posts= response.data;
        setReviewsVisible(true);
        setHotelId(posts.hotelId);
        setHotel(response.data);
       
    })
    .catch((error)=>{
      console.log(error);
    })
  },[]);

  

  return (
    <div class="view_hotel">
      <div class="container">
        <div class="row justify-content-center">
          <div class="col-md-7 col-lg-4 mb-5 mb-lg-0 wow fadeIn">
            <div class="card border-0 shadow">
              <img src={hotel.image} alt="" />
              <div class="card-body p-1-9 p-xl-5">
                <div class="mb-4">
                  <h3 class="h4 mb-0">{hotel.hotelName}</h3>
                  <span class="text-primary"><svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-geo" viewBox="0 0 16 16">
  <path fill-rule="evenodd" d="M8 1a3 3 0 1 0 0 6 3 3 0 0 0 0-6M4 4a4 4 0 1 1 4.5 3.969V13.5a.5.5 0 0 1-1 0V7.97A4 4 0 0 1 4 3.999zm2.493 8.574a.5.5 0 0 1-.411.575c-.712.118-1.28.295-1.655.493a1.319 1.319 0 0 0-.37.265.301.301 0 0 0-.057.09V14l.002.008a.147.147 0 0 0 .016.033.617.617 0 0 0 .145.15c.165.13.435.27.813.395.751.25 1.82.414 3.024.414s2.273-.163 3.024-.414c.378-.126.648-.265.813-.395a.619.619 0 0 0 .146-.15.148.148 0 0 0 .015-.033L12 14v-.004a.301.301 0 0 0-.057-.09 1.318 1.318 0 0 0-.37-.264c-.376-.198-.943-.375-1.655-.493a.5.5 0 1 1 .164-.986c.77.127 1.452.328 1.957.594C12.5 13 13 13.4 13 14c0 .426-.26.752-.544.977-.29.228-.68.413-1.116.558-.878.293-2.059.465-3.34.465-1.281 0-2.462-.172-3.34-.465-.436-.145-.826-.33-1.116-.558C3.26 14.752 3 14.426 3 14c0-.599.5-1 .961-1.243.505-.266 1.187-.467 1.957-.594a.5.5 0 0 1 .575.411"/>
</svg>&nbsp; {hotel.city}</span>
                </div>
                <ul class="list-unstyled mb-4">
                  <li class="mb-3"><svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-envelope" viewBox="0 0 16 16">
  <path d="M0 4a2 2 0 0 1 2-2h12a2 2 0 0 1 2 2v8a2 2 0 0 1-2 2H2a2 2 0 0 1-2-2zm2-1a1 1 0 0 0-1 1v.217l7 4.2 7-4.2V4a1 1 0 0 0-1-1zm13 2.383-4.708 2.825L15 11.105zm-.034 6.876-5.64-3.471L8 9.583l-1.326-.795-5.64 3.47A1 1 0 0 0 2 13h12a1 1 0 0 0 .966-.741M1 11.105l4.708-2.897L1 5.383z"/>
</svg>&nbsp; {hotel.userId}</li><br/>
                  <li class="mb-3"><svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-telephone" viewBox="0 0 16 16">
  <path d="M3.654 1.328a.678.678 0 0 0-1.015-.063L1.605 2.3c-.483.484-.661 1.169-.45 1.77a17.568 17.568 0 0 0 4.168 6.608 17.569 17.569 0 0 0 6.608 4.168c.601.211 1.286.033 1.77-.45l1.034-1.034a.678.678 0 0 0-.063-1.015l-2.307-1.794a.678.678 0 0 0-.58-.122l-2.19.547a1.745 1.745 0 0 1-1.657-.459L5.482 8.062a1.745 1.745 0 0 1-.46-1.657l.548-2.19a.678.678 0 0 0-.122-.58L3.654 1.328zM1.884.511a1.745 1.745 0 0 1 2.612.163L6.29 2.98c.329.423.445.974.315 1.494l-.547 2.19a.678.678 0 0 0 .178.643l2.457 2.457a.678.678 0 0 0 .644.178l2.189-.547a1.745 1.745 0 0 1 1.494.315l2.306 1.794c.829.645.905 1.87.163 2.611l-1.034 1.034c-.74.74-1.846 1.065-2.877.702a18.634 18.634 0 0 1-7.01-4.42 18.634 18.634 0 0 1-4.42-7.009c-.362-1.03-.037-2.137.703-2.877L1.885.511z"/>
</svg>&nbsp; {hotel.phone}</li><br/>
                  <li class="mb-3"><svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-geo-alt" viewBox="0 0 16 16">
  <path d="M12.166 8.94c-.524 1.062-1.234 2.12-1.96 3.07A31.493 31.493 0 0 1 8 14.58a31.481 31.481 0 0 1-2.206-2.57c-.726-.95-1.436-2.008-1.96-3.07C3.304 7.867 3 6.862 3 6a5 5 0 0 1 10 0c0 .862-.305 1.867-.834 2.94M8 16s6-5.686 6-10A6 6 0 0 0 2 6c0 4.314 6 10 6 10"/>
  <path d="M8 8a2 2 0 1 1 0-4 2 2 0 0 1 0 4m0 1a3 3 0 1 0 0-6 3 3 0 0 0 0 6"/>
</svg>&nbsp; {hotel.address}</li>
                </ul>
              </div>
            </div>
          </div>
          <div class="col-lg-8">
            <div class="ps-lg-1-6 ps-xl-5">
              <div class="mb-5 wow fadeIn">
                <div class="text-start mb-1-6 wow fadeIn">
                  <h2 class="h1 mb-0 text-primary">Description</h2>
                </div>
                <p>{hotel.description}</p>
              </div>
              <div class="mb-5 wow fadeIn">
                <div class="text-start mb-1-6 wow fadeIn">
                  <h2 class="mb-0 text-primary">Available Rooms</h2>
                </div>
                <div class="row mt-n4">
                   {reviewsVisible && <AdminRooms hotel={{hotelId:hotel.hotelId,checkIn:checkIn,checkOut:checkOut}}/> }
                </div>
              </div>
              <div class="wow fadeIn">
                <div class="text-start mb-1-6 wow fadeIn">
                  <h2 class="mb-0 text-primary">Reviews &amp; Ratings</h2>
                </div>
                {reviewsVisible && <Reviews id={hotelId} />}
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}

export default ViewAdminHotel;
