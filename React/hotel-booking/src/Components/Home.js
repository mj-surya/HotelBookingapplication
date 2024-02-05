import './Home.css';
import { Link, useNavigate} from "react-router-dom";

function Home() {
  const navigate=useNavigate();
  const explore=()=>{
    if(localStorage.getItem("role")=="Admin"){
      navigate('/ViewAdminHotel');
    }
    else{
      navigate('/Hotels');
    }
    
  }
  return (
    <div className="home">
      <div id="carouselExampleIndicators" className="carousel slide" data-bs-ride="carousel">
        <div className="carousel-indicators">
          <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="0" className="active" aria-current="true" aria-label="Slide 1"></button>
          <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="1" aria-label="Slide 2"></button>
          <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="2" aria-label="Slide 3"></button>
        </div>
        <div className="carousel-inner">
          <div className="carousel-item active">
            <img src="https://images.unsplash.com/photo-1618064541372-289bdb6f5b7b?q=80&w=1933&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" className="d-block w-100" alt="..." />
          </div>
          <div className="carousel-item">
            <img src="https://images.unsplash.com/photo-1618064541372-289bdb6f5b7b?q=80&w=1933&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" className="d-block w-100" alt="..." />
          </div>
          <div className="carousel-item">
            <img src="https://images.unsplash.com/photo-1590523277543-a94d2e4eb00b?q=80&w=1932&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" className="d-block w-100" alt="..." />
          </div>
        </div>
        <button className="carousel-control-prev" type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide="prev">
          <span className="carousel-control-prev-icon" aria-hidden="true"></span>
          <span className="visually-hidden">Previous</span>
        </button>
        <button className="carousel-control-next" type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide="next">
          <span className="carousel-control-next-icon" aria-hidden="true"></span>
          <span className="visually-hidden">Next</span>
        </button>
        <div className="center-button-container">
          <h1>Indulge in Elegance, Embrace Comfort – Unveiling Our Exclusive Hotel Experience.</h1>
          <button className="center-button btn bg-transparent" onClick={explore}>Explore</button>
        </div>
      </div>
    </div>
  );
}

export default Home;
