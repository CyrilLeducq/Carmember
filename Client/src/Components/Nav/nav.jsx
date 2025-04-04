import { useState } from "react";
import "../Nav/nav.css";
import Nom from "../../assets/Nom.png";
import Logo from "../../assets/logo.png"

function Nav() {
  const [isOpen, setIsOpen] = useState(false);

  const toggleAccordion = () => {
    setIsOpen(!isOpen);
  };

  return (
    <div className="nav-components">
      <div className="nav-name">
        <a href="">
        <img src={Nom} alt="logo de car'member" />
        </a>
      </div>
    <div className="button-component">

      <button className="nav-button-publi">Publier un <br></br> trajet</button>

      <div className="nav-profil-container">
        <button className="nav-button-profil" onClick={toggleAccordion}>
          <svg
            xmlns="http://www.w3.org/2000/svg"
            width="32"
            height="32"
            fill="currentColor"
            className="bi bi-person-circle"
            viewBox="0 0 16 16"
          >
            <path d="M11 6a3 3 0 1 1-6 0 3 3 0 0 1 6 0" />
            <path
              fillRule="evenodd"
              d="M0 8a8 8 0 1 1 16 0A8 8 0 0 1 0 8m8-7a7 7 0 0 0-5.468 
              11.37C3.242 11.226 4.805 10 8 10s4.757 1.225 5.468 
              2.37A7 7 0 0 0 8 1"
            />
          </svg>
          <svg xmlns="http://www.w3.org/2000/svg"
           width="27" 
           height="27" 
           fill="currentColor" 
           className={`bi bi-caret-down-fill ${isOpen ? "rotate" : ""}`} 
           viewBox="0 0 16 16">
            <path d="M7.247 11.14 2.451 5.658C1.885 5.013 2.345 4 3.204 4h9.592a1 1 0 0 1 .753 1.659l-4.796 5.48a1 1 0 0 1-1.506 0z"/>
        </svg>
        </button>

        {isOpen && (
          <div className="nav-accordion">
            <a href="/">Connexion</a>
            <hr />
            <a href="/">Inscription</a>
            <hr />
            <a href="/">Profil</a>
            <hr />
            <a href="/">Déconnexion</a>
          </div>
        )}
      </div>
    </div>
      <div className="nav-logo">
        <img src={Logo} alt="logo de car'member" />
      </div>
    </div>
  );
}

export default Nav;
