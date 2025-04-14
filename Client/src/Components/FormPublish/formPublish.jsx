import "../FormPublish/FormPublish.css";
import { useState } from "react";
import axios from "axios";
import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";
import CheeseSelect from "../CheeseSelect/cheeseSelect.jsx";
import AnimationCar from "../../Components/AnimationCar/animationCar";

function FormPublish() {
  const [departure, setDeparture] = useState("");
  const [destination, setDestination] = useState("");
  const [departureSuggestions, setDepartureSuggestions] = useState([]);
  const [destinationSuggestions, setDestinationSuggestions] = useState([]);
  const [isOpen, setIsOpen] = useState(false);
  const [startDate, setStartDate] = useState(null);
  const [departureTime, setDepartureTime] = useState("");
  const [arrivalTime, setArrivalTime] = useState("");
  const [cheeseWeight, setCheeseWeight] = useState("");
  const [cheeseType, setCheeseType] = useState(""); // Tu dois modifier CheeseSelect pour qu’il donne une valeur ici

  const apiKey = import.meta.env.VITE_GEODB_API_KEY || "c27264e6d6mshadab7c7b91cd300p11e66ejsnf0635bbccd2e";

  const handleCalendarClick = () => setIsOpen(!isOpen);

  const handleAutocomplete = async (value, setValue, setSuggestions) => {
    setValue(value);
    if (value.length >= 2 && apiKey) {
      try {
        const res = await axios.get("https://wft-geo-db.p.rapidapi.com/v1/geo/cities", {
          params: {
            namePrefix: value,
            countryIds: "FR",
            limit: 5,
            sort: "-population",
          },
          headers: {
            "X-RapidAPI-Key": apiKey,
            "X-RapidAPI-Host": "wft-geo-db.p.rapidapi.com",
          },
        });
        const villes = res.data.data.map((v) => v.city);
        setSuggestions(villes);
      } catch (err) {
        console.error("Erreur API GeoDB :", err);
        setSuggestions([]);
      }
    } else {
      setSuggestions([]);
    }
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      const data = {
        departure,
        destination,
        date: startDate,
        departureTime,
        arrivalTime,
        cheeseWeight,
        cheeseType,
      };
      const response = await axios.post("/api/trajet", data); // 🔁 Modifie cette URL selon ton backend
      console.log("✅ Données envoyées :", response.data);
      alert("Trajet publié avec succès !");
    } catch (error) {
      console.error("❌ Erreur d'envoi :", error);
      alert("Erreur lors de la publication du trajet.");
    }
  };

return (
<form className="formPublish-contenant" onSubmit={handleSubmit}>
  <div className="town-choice">

  {/* Départ */}
  <div className="depart-publish" style={{ position: "relative" }}>
    <svg xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" width="40" height="41"
      viewBox="0 0 40 41" fill="none">
      <rect width="40" height="41" fill="#F5F5F5" />
      <rect width="1440" height="2409" transform="translate(-243 -566)" fill="#000A27" />
      <path d="M1197 -408H-243V21H1197V-408Z" fill="url(#pattern0_1081_2)" />
      <rect x="-30" y="-15" width="1014" height="70.5047" rx="12.675" fill="white" />
      <path
        d="M25.3541 35.1058C25.748 35.1058 26.1258 34.9493 26.4044 34.6708C26.683 34.3922 26.8395 34.0144 26.8395 33.6205C26.8395 33.2265 26.683 32.8487 26.4044 32.5702C26.1258 32.2916 25.748 32.1351 25.3541 32.1351H12.9762C11.9257 32.1351 10.9182 31.7178 10.1754 30.975C9.43255 30.2322 9.01524 29.2247 9.01524 28.1742V12.3304C9.01524 11.2799 9.43255 10.2725 10.1754 9.52964C10.9182 8.78682 11.9257 8.36951 12.9762 8.36951H25.3541C25.748 8.36951 26.1258 8.21302 26.4044 7.93446C26.683 7.6559 26.8395 7.2781 26.8395 6.88416C26.8395 6.49022 26.683 6.11241 26.4044 5.83385C26.1258 5.5553 25.748 5.3988 25.3541 5.3988H12.9762C11.1378 5.3988 9.3747 6.1291 8.07476 7.42903C6.77483 8.72897 6.04453 10.4921 6.04453 12.3304V28.1742C6.04453 30.0126 6.77483 31.7757 8.07476 33.0756C9.3747 34.3755 11.1378 35.1058 12.9762 35.1058H25.3541ZM27.3167 12.7246C27.46 12.5921 27.628 12.4893 27.8111 12.4218C27.9941 12.3543 28.1887 12.3235 28.3836 12.3313C28.5786 12.339 28.7701 12.385 28.9472 12.4668C29.1244 12.5486 29.2837 12.6644 29.416 12.8077L35.3575 19.2443C35.6111 19.5187 35.7519 19.8786 35.7519 20.2523C35.7519 20.626 35.6111 20.9859 35.3575 21.2604L29.416 27.6969C29.1484 27.9861 28.7769 28.1571 28.3832 28.1723C27.9895 28.1875 27.6059 28.0457 27.3167 27.7781C27.0276 27.5105 26.8566 27.139 26.8414 26.7453C26.8261 26.3516 26.9679 25.968 27.2355 25.6788L30.8757 21.7357H15.4518C15.0578 21.7357 14.68 21.5792 14.4015 21.3006C14.1229 21.0221 13.9664 20.6443 13.9664 20.2503C13.9664 19.8564 14.1229 19.4786 14.4015 19.2C14.68 18.9215 15.0578 18.765 15.4518 18.765H30.8737L27.2336 14.8219C27.1012 14.6786 26.9983 14.5106 26.9308 14.3276C26.8633 14.1445 26.8326 13.9499 26.8403 13.755C26.848 13.56 26.8941 13.3685 26.9758 13.1914C27.0576 13.0142 27.1734 12.8569 27.3167 12.7246Z"
        fill="#474C5A" />
      <defs>
        <pattern id="pattern0_1081_2" patternContentUnits="objectBoundingBox" width="1" height="1">
          <use xlink:href="#image0_1081_2" transform="matrix(0.00024542 0 0 0.000979742 0.000179894 -0.373871)" />
        </pattern>
      </defs>
    </svg>
    <input className="depart-input" placeholder="Départ" name="departure" value={departure} onChange={(e)=>
    handleAutocomplete(e.target.value, setDeparture, setDepartureSuggestions)
    }
    required
    autoComplete="off"
    />
    {departureSuggestions.length > 0 && (
    <ul className="suggestions-list">
      {departureSuggestions.map((ville, i) => (
      <li key={i} onClick={()=> {
        setDeparture(ville);
        setDepartureSuggestions([]);
        }}
        >
        {ville}
      </li>
      ))}
    </ul>
    )}
  </div>
  {/* Destination */}
  <div className="destination-publish" style={{ position: "relative" }}>
    <svg xmlns="http://www.w3.org/2000/svg" width="34" height="31" viewBox="0 0 34 31" fill="none">
      <path
        d="M14.2299 30.1058C13.836 30.1058 13.4581 29.9493 13.1796 29.6708C12.901 29.3922 12.7445 29.0144 12.7445 28.6205C12.7445 28.2265 12.901 27.8487 13.1796 27.5702C13.4581 27.2916 13.836 27.1351 14.2299 27.1351H26.6078C27.6583 27.1351 28.6658 26.7178 29.4086 25.975C30.1514 25.2322 30.5688 24.2247 30.5688 23.1742V7.33044C30.5688 6.27994 30.1514 5.27246 29.4086 4.52964C28.6658 3.78682 27.6583 3.36951 26.6078 3.36951H14.2299C13.836 3.36951 13.4581 3.21302 13.1796 2.93446C12.901 2.6559 12.7445 2.2781 12.7445 1.88416C12.7445 1.49022 12.901 1.11241 13.1796 0.833853C13.4581 0.555295 13.836 0.398804 14.2299 0.398804H26.6078C28.4462 0.398804 30.2093 1.1291 31.5092 2.42903C32.8092 3.72897 33.5395 5.49206 33.5395 7.33044V23.1742C33.5395 25.0126 32.8092 26.7757 31.5092 28.0756C30.2093 29.3755 28.4462 30.1058 26.6078 30.1058H14.2299ZM14.2121 7.72456C14.3554 7.59215 14.5233 7.48926 14.7064 7.42178C14.8894 7.3543 15.084 7.32355 15.2789 7.33127C15.4739 7.33899 15.6654 7.38505 15.8426 7.4668C16.0197 7.54856 16.179 7.66441 16.3114 7.80774L22.2528 14.2443C22.5064 14.5187 22.6472 14.8786 22.6472 15.2523C22.6472 15.626 22.5064 15.9859 22.2528 16.2604L16.3114 22.6969C16.1789 22.8401 16.0194 22.9557 15.8422 23.0373C15.665 23.1189 15.4735 23.1647 15.2785 23.1723C15.0836 23.1798 14.8891 23.1489 14.7061 23.0813C14.5231 23.0136 14.3552 22.9106 14.2121 22.7781C14.0689 22.6456 13.9532 22.4862 13.8717 22.309C13.7901 22.1318 13.7442 21.9402 13.7367 21.7453C13.7215 21.3516 13.8632 20.968 14.1309 20.6788L17.771 16.7357H2.34708C1.95314 16.7357 1.57533 16.5792 1.29677 16.3006C1.01822 16.0221 0.861725 15.6443 0.861725 15.2503C0.861725 14.8564 1.01822 14.4786 1.29677 14.2C1.57533 13.9215 1.95314 13.765 2.34708 13.765H17.769L14.1289 9.82385C13.9965 9.68057 13.8936 9.5126 13.8261 9.32954C13.7586 9.14648 13.7279 8.95192 13.7356 8.75698C13.7433 8.56203 13.7894 8.37051 13.8711 8.19337C13.9529 8.01622 14.0687 7.85692 14.2121 7.72456Z"
        fill="#474C5A" />
    </svg>
    <input className="destination-input" placeholder="Destination" name="destination" value={destination}
      onChange={(e)=>
    handleAutocomplete(e.target.value, setDestination, setDestinationSuggestions)
    }
    required
    autoComplete="off"
    />
    {destinationSuggestions.length > 0 && (
    <ul className="suggestions-list">
      {destinationSuggestions.map((ville, i) => (
      <li key={i} onClick={()=> {
        setDestination(ville);
        setDestinationSuggestions([]);
        }}
        >
        {ville}
      </li>
      ))}
    </ul>
    )}
  </div>
  </div>
  <div className="time-choice">
  {/* Date */}
  <button className="btn-calendar-publish" onClick={handleCalendarClick} type="button">
  <svg className="calendar-grey" xmlns="http://www.w3.org/2000/svg" width="35" height="35" viewBox="0 0 41 41" fill="none">
<g id="icone calendrier">
<path id="Vector" d="M15.9547 19.0023C15.9547 18.6708 15.823 18.3529 15.5885 18.1184C15.3541 17.884 15.0362 17.7523 14.7047 17.7523H12.2047C11.8731 17.7523 11.5552 17.884 11.3208 18.1184C11.0863 18.3529 10.9547 18.6708 10.9547 19.0023V21.5023C10.9547 21.8338 11.0863 22.1518 11.3208 22.3862C11.5552 22.6206 11.8731 22.7523 12.2047 22.7523H14.7047C15.0362 22.7523 15.3541 22.6206 15.5885 22.3862C15.823 22.1518 15.9547 21.8338 15.9547 21.5023V19.0023ZM15.9547 26.5023C15.9547 26.1708 15.823 25.8529 15.5885 25.6184C15.3541 25.384 15.0362 25.2523 14.7047 25.2523H12.2047C11.8731 25.2523 11.5552 25.384 11.3208 25.6184C11.0863 25.8529 10.9547 26.1708 10.9547 26.5023V29.0023C10.9547 29.3338 11.0863 29.6518 11.3208 29.8862C11.5552 30.1206 11.8731 30.2523 12.2047 30.2523H14.7047C15.0362 30.2523 15.3541 30.1206 15.5885 29.8862C15.823 29.6518 15.9547 29.3338 15.9547 29.0023V26.5023ZM19.7047 17.7523H22.2047C22.5362 17.7523 22.8541 17.884 23.0885 18.1184C23.323 18.3529 23.4547 18.6708 23.4547 19.0023V21.5023C23.4547 21.8338 23.323 22.1518 23.0885 22.3862C22.8541 22.6206 22.5362 22.7523 22.2047 22.7523H19.7047C19.3731 22.7523 19.0552 22.6206 18.8208 22.3862C18.5863 22.1518 18.4547 21.8338 18.4547 21.5023V19.0023C18.4547 18.6708 18.5863 18.3529 18.8208 18.1184C19.0552 17.884 19.3731 17.7523 19.7047 17.7523ZM22.2047 25.2523H19.7047C19.3731 25.2523 19.0552 25.384 18.8208 25.6184C18.5863 25.8529 18.4547 26.1708 18.4547 26.5023V29.0023C18.4547 29.3338 18.5863 29.6518 18.8208 29.8862C19.0552 30.1206 19.3731 30.2523 19.7047 30.2523H22.2047C22.5362 30.2523 22.8541 30.1206 23.0885 29.8862C23.323 29.6518 23.4547 29.3338 23.4547 29.0023V26.5023C23.4547 26.1708 23.323 25.8529 23.0885 25.6184C22.8541 25.384 22.5362 25.2523 22.2047 25.2523ZM25.9547 19.0023C25.9547 18.6708 26.0863 18.3529 26.3208 18.1184C26.5552 17.884 26.8731 17.7523 27.2047 17.7523H29.7047C30.0362 17.7523 30.3541 17.884 30.5885 18.1184C30.823 18.3529 30.9547 18.6708 30.9547 19.0023V21.5023C30.9547 21.8338 30.823 22.1518 30.5885 22.3862C30.3541 22.6206 30.0362 22.7523 29.7047 22.7523H27.2047C26.8731 22.7523 26.5552 22.6206 26.3208 22.3862C26.0863 22.1518 25.9547 21.8338 25.9547 21.5023V19.0023Z" fill="#474C5A"/>
<path id="Vector_2" fill-rule="evenodd" clip-rule="evenodd" d="M12.2047 0.252319C12.5362 0.252319 12.8541 0.384015 13.0885 0.618436C13.323 0.852856 13.4547 1.1708 13.4547 1.50232V2.75232H28.4547V1.50232C28.4547 1.1708 28.5863 0.852856 28.8208 0.618436C29.0552 0.384015 29.3731 0.252319 29.7047 0.252319C30.0362 0.252319 30.3541 0.384015 30.5885 0.618436C30.823 0.852856 30.9547 1.1708 30.9547 1.50232V2.75232C35.1047 2.75232 38.4547 6.10232 38.4547 10.2523V30.2523C38.4547 34.4023 35.1047 37.7523 30.9547 37.7523H10.9547C6.80465 37.7523 3.45465 34.4023 3.45465 30.2523V10.2523C3.45465 6.10232 6.80465 2.75232 10.9547 2.75232V1.50232C10.9547 1.1708 11.0863 0.852856 11.3208 0.618436C11.5552 0.384015 11.8731 0.252319 12.2047 0.252319ZM35.9547 10.2523V12.7523H5.95465V10.2523C5.95465 7.50232 8.19215 5.25232 10.9547 5.25232V6.50232C10.9547 6.83384 11.0863 7.15178 11.3208 7.3862C11.5552 7.62062 11.8731 7.75232 12.2047 7.75232C12.5362 7.75232 12.8541 7.62062 13.0885 7.3862C13.323 7.15178 13.4547 6.83384 13.4547 6.50232V5.25232H28.4547V6.50232C28.4547 6.83384 28.5863 7.15178 28.8208 7.3862C29.0552 7.62062 29.3731 7.75232 29.7047 7.75232C30.0362 7.75232 30.3541 7.62062 30.5885 7.3862C30.823 7.15178 30.9547 6.83384 30.9547 6.50232V5.25232C33.7047 5.25232 35.9547 7.48982 35.9547 10.2523ZM5.95465 30.2523V15.2523H35.9547V30.2523C35.9547 33.0023 33.7172 35.2523 30.9547 35.2523H10.9547C8.20465 35.2523 5.95465 33.0148 5.95465 30.2523Z" fill="#474C5A"/>
</g>
</svg>
    {startDate ? startDate.toLocaleDateString() : "Choisir une date"}
  </button>
  {isOpen && (
  <div style={{ position: "absolute", zIndex: 10 }}>
    <DatePicker selected={startDate} onChange={(date)=> {
      setStartDate(date);
      setIsOpen(false);
      }}
      minDate={new Date()}
      inline
      />
  </div>
  )}
  {/* heure */}
  <button className="time-trajet">
    <label for="departure">Heure de départ</label>
    <input type="time" id="departureTime" value={departureTime} onChange={(e) => setDepartureTime(e.target.value)} min="06:00" max="23:00" required />

    <label for="arrived">Heure d'arrivée</label>
    <input type="time" id="arrivalTime" value={arrivalTime} onChange={(e) => setArrivalTime(e.target.value)} min="06:00" max="23:59" required />  </button>
  </div>
  {/* choix fromage */}
  <div className="contenant-bottom">
    <div className="animationCar">
      <AnimationCar/>
    </div>
    <div className="choice-cheese">
    <div className="choice-contenant-top">
      <svg xmlns="http://www.w3.org/2000/svg" width="30" height="30" viewBox="0 0 45 45" fill="none">
                    <path
                        d="M21.6541 3.87545C22.7016 3.87421 23.7488 3.91173 24.7935 3.98795L25.5625 4.63896C24.6687 5.18933 24.0684 6.00724 23.9118 6.92974C23.7372 7.95718 24.1329 9.04527 24.9775 9.87953C26.6665 11.548 29.4959 11.9611 31.6324 10.8766C31.8985 10.7421 32.1498 10.5801 32.3821 10.3932L43.5278 19.8L37.0376 18.0972C36.3753 16.4363 34.7226 15.14 32.7915 14.7931C32.4851 14.7375 32.1744 14.7091 31.8631 14.708C30.9543 14.7068 30.1114 14.9527 29.4325 15.4221C29.2143 15.5724 29.0144 15.7475 28.8366 15.9438L3.13946 9.20083C7.09243 5.75939 14.3212 3.87906 21.6541 3.87537V3.87545ZM1.8813 10.4397L28.092 17.2706C27.9954 17.5921 27.9409 17.9333 27.9409 18.2869C27.9409 20.6643 29.9872 22.7245 32.5003 23.1758C33.7569 23.4014 34.9516 23.1699 35.8568 22.544C36.7619 21.9183 37.3482 20.871 37.3482 19.6821L43.2694 21.2256V29.6082C43.2425 29.6011 43.2231 29.5897 43.1953 29.5836C41.93 29.2926 40.7174 29.473 39.7949 30.075C38.8724 30.6771 38.2787 31.7268 38.2787 32.9233C38.2787 35.3163 40.3131 37.4708 42.8382 38.0512C42.988 38.0855 43.1273 38.0993 43.2694 38.1171V39.2789L25.466 34.6372C25.7015 34.1382 25.8234 33.5932 25.8231 33.0414C25.8231 30.711 23.6547 28.8199 20.9782 28.8199C18.6914 28.8199 16.7749 30.2005 16.265 32.0554C16.1451 32.0853 16.0237 32.1157 15.9025 32.1486L1.88113 28.537V10.4397L1.8813 10.4397ZM31.8631 16.3504C32.0768 16.3509 32.29 16.3703 32.5003 16.4081C34.2761 16.7272 35.7057 18.3236 35.7057 19.6821C35.7057 20.3615 35.4231 20.8469 34.9229 21.1927C34.4228 21.5386 33.6794 21.7174 32.7916 21.558C31.0158 21.2391 29.5835 19.6455 29.5835 18.2869C29.5835 17.6077 29.8661 17.1194 30.3663 16.7736C30.7414 16.5141 31.2556 16.3497 31.8631 16.3506V16.3504ZM10.113 21.9782C8.29415 21.9782 6.69903 23.3001 6.69903 25.0572C6.69903 26.8143 8.29407 28.1388 10.1129 28.1388C11.9318 28.1388 13.5296 26.8143 13.5296 25.0572C13.5296 23.3001 11.9318 21.9784 10.1129 21.9784L10.113 21.9782ZM10.113 23.6207C11.1585 23.6207 11.8873 24.3191 11.8873 25.0572C11.8873 25.7952 11.1585 26.4937 10.113 26.4937C9.06741 26.4937 8.34144 25.7952 8.34144 25.0572C8.34144 24.3192 9.06741 23.6207 10.113 23.6207Z"
                        fill="white" />
      </svg>
      <span>Quantité</span>
    </div>
    <div className="choice-contenant-bottom">
    <CheeseSelect onChange={(value) => setCheeseType(value)} />
          <label className="cheese-gr">
          <input type="number" className="weight-cheese" placeholder="Poids" name="weight-cheese" min={1} value={cheeseWeight} onChange={(e) => setCheeseWeight(e.target.value)} required />
          gr
          </label>
    </div>  
  </div>
  </div>
  <div className="btn-submit">
  <button type="submit" className="submit-envoi">Publier</button>
  </div>
</form>
);
}

export default FormPublish;
