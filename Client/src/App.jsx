import { BrowserRouter as Router, Routes, Route, useLocation } from "react-router-dom";
import Home from "./Pages/Home/home";
import Footer from "./Components/Footer/footer";
import Nav from "./Components/Nav/nav";
import NavDefault from "./Components/NavDefault/navDefault";
import NavProfil from "./Components/NavProfil/navProfil"
import Subscrire from "./Pages/Subscribe/subscribe";
import Publish from "./Pages/Publish/publish";
import Profil from "./Pages/Profil/profil";
import Contact from "./Pages/Contact/contact";
import Cookies from "./Pages/Cookies/cookies";
import Connexion from "./Pages/Connexion/connexion";
import Find from "./Pages/Find/find";
import Compte from "./Pages/Compte/compte";
import Qui from "./Pages/Qui/qui";
import Avis from "./Pages/Avis/avis"
import Trajet from "./Pages/Trajet/trajet";
import Info from "./Pages/Info/info";

function Layout() {
  const location = useLocation();
  const isHome = location.pathname === "/";
  const isProfil = location.pathname === "/Profil"

  return (
    <>
      {isHome ? (  <Nav />) : isProfil ? (  <NavProfil />) : (  <NavDefault />)}

      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/Inscription" element={<Subscrire />} />
        <Route path="/Publier" element={<Publish />} />
        <Route path="/Profil" element={<Profil />} />
        <Route path="/Contact" element={<Contact />} />
        <Route path="/Cookies" element={<Cookies />} />
        <Route path="/Connexion" element={<Connexion />} />
        <Route path="/Rechercher" element={<Find />} />
        <Route path="/COMPTE" element={<Compte/>} />
        <Route path="/QUI" element={<Qui/>} />
        <Route path="/Avis" element={<Avis/>} />
        <Route path="/Trajet" element={<Trajet/>}/>
        <Route path="/Informations" element={<Info/>}/>
        {/* <Route path="/about" element={<About />} />
        <Route path="*" element={<NotFound />} /> */}
      </Routes>
      <Footer />
    </>
  );
}

function App() {
  return (
    <Router>
      <Layout />
    </Router>
  );
}

export default App;
