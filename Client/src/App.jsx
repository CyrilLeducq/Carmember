import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Home from "./Pages/Home/home";
import Footer from "./Components/Footer/footer"
import Nav from "./Components/Nav/nav"
import Subscrire from "./Pages/Subscribe/subscribe";
import Publish from "./Pages/Publish/publish";
import Profil from "./Pages/Profil/profil"
import Contact from "./Pages/Contact/contact"
import Cookies from "./Pages/Cookies/cookies";
import Connexion  from "./Pages/Connexion/connexion";
import Find from "./Pages/Find/find"
function App() {
  return (
    <Router>
      <Nav />
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/Inscription" element={<Subscrire />} />
        <Route path="/Publier" element={<Publish />} />
        <Route path="/Profil" element={<Profil />} />
        <Route path="/Contact" element={<Contact />} />
        <Route path="/Cookies" element={<Cookies />} />
        <Route path="/Connexion" element={<Connexion />} />
        <Route path="/Rechercher" element={<Find />} />

        {/* <Route path="/about" element={<About />} />
        <Route path="*" element={<NotFound />} /> */}
      </Routes>
      <Footer/>
    </Router>
  );
}

export default App;