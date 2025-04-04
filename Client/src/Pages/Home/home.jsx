import car from "../../assets/car.png"
import "../Home/home.css"
import SearchBar from "../../Components/SearchBar/SearchBar";
import Card from "../../Components/Card/card";

function Home() {
    return (  
        <div className="home-contenant">
            <div className="home-image">
                <img src={car} alt="image de voiture pour la page accueil de car Menber" />
            </div>
            <SearchBar/>
            <div className="card-conteneur">
            <Card
            text=""
            accentColor="#2dd4bf"
            backgroundColor="#ffffff"
            textColor="#1e293b"
            />
            <Card
            text=""
            accentColor="#facc15"
            backgroundColor="#1e293b"
            textColor="#ffffff"
            />

            <Card
            text=""
            accentColor="#fb923c"
            backgroundColor="#fff7ed"
            textColor="#78350f"
            />
            </div>
        </div>
    );
}

export default Home;