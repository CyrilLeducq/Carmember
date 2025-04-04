import car from "../../assets/car.png"
import "../Home/home.css"
import SearchBar from "../../Components/SearchBar/SearchBar";
function Home() {
    return (  
        <div className="home-contenant">
            <div className="home-image">
                <img src={car} alt="image de voiture pour la page accueil de car Menber" />
            </div>
            <SearchBar/>
        </div>
    );
}

export default Home;