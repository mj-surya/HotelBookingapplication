import './Menu.css';
import { Link, Navigate } from "react-router-dom";


function Menu(){
    
    const logout=()=>{
        localStorage.clear();
        window.reload();

    }
    
    return(
        <nav class="navbar fixed-top navbar-expand-sm navbar-light bg-light pad ">
            <a class="navbar-brand pad" href="#">Stay Quest</a>
            <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbar-collapse">☰</button> 
            <div class="collapse navbar-collapse" id="navbar-collapse">
                <ul class="nav navbar-nav ml-auto">
                    <li class="nav-item active"> <Link class="nav-link" to="/Home">Home</Link>
                    </li>
                    <li class="nav-item dropdown"> 
                        <a class="nav-link dropdown-toggle" data-bs-toggle="dropdown" href="#" role="button" aria-haspopup="true" aria-expanded="false">Hotels</a>
                        <div class="dropdown-menu dropdown-menu-right">
                            <Link class="dropdown-item" to="/AddHotel">Add Hotel</Link>
                            <a class="dropdown-item" href="#">Update Hotel</a>
                            <a class="dropdown-item" href="#">Delete Hotel</a>
                        </div>
                    </li>
                    <li class="nav-item dropdown"> 
                        <a class="nav-link dropdown-toggle" data-bs-toggle="dropdown" href="#" role="button" aria-haspopup="true" aria-expanded="false">Rooms</a>
                        <div class="dropdown-menu dropdown-menu-right">
                        <Link class="dropdown-item" to="/AddRoom">Add Room</Link>
                            <Link class="dropdown-item" to="/GetRoom">Update Room</Link>
                            <Link class="dropdown-item" to="AddBooking">Delete Room</Link>
                        </div>
                    </li>
                    <li class="nav-item"> <a class="nav-link" href="#">Bookings</a>
                    </li>
                    <li class="nav-item dropdown"> 
                        <a class="nav-link dropdown-toggle" data-bs-toggle="dropdown"  role="button" aria-haspopup="true" aria-expanded="false">UserName</a>
                        <div class="dropdown-menu dropdown-menu-right">
                            <Link class="dropdown-item" to="/Login">Login</Link>
                            <Link class="dropdown-item" to="/Home" onClick={logout}>logout</Link>
                        </div>
                    </li>
                </ul>
            </div>
        </nav>
    )
}

export default Menu;