import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Home from "./Pages/Home/home";
import Footer from "./Components/Footer/footer"
import Nav from "./Components/Nav/nav"
import Subscrire from "./Pages/Subscribe/subscribe";
import Publish from "./Pages/Publish/publish";
import Profil from "./Pages/Profil/profil"
import Contact from "./Pages/Contact/contact"

function App() {
  return (
    <Router>
      <Nav />
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/Subscrire" element={<Subscrire />} />
        <Route path="/Publish" element={<Publish />} />
        <Route path="/Profil" element={<Profil />} />
        <Route path="/Contact" element={<Contact />} />
        {/* <Route path="/about" element={<About />} />
        <Route path="*" element={<NotFound />} /> */}
      </Routes>
      <Footer/>
    </Router>
  );
}

export default App;