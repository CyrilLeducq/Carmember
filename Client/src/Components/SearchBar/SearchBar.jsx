import { useState } from "react";
import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";
import "../SearchBar/SearchBar.css";
import axios from "axios";

function SearchBar() {
  const [startDate, setStartDate] = useState(null);
  const [isOpen, setIsOpen] = useState(false);
  const [departure, setDeparture] = useState("");
  const [destination, setDestination] = useState("");
  const [passengerCount, setPassengerCount] = useState(1);
  const [isPassengerOpen, setIsPassengerOpen] = useState(false);
  const [departureSuggestions, setDepartureSuggestions] = useState([]);
  const [destinationSuggestions, setDestinationSuggestions] = useState([]);

  const apiKey = import.meta.env.VITE_GEODB_API_KEY || "c27264e6d6mshadab7c7b91cd300p11e66ejsnf0635bbccd2e";

  if (!apiKey) {
    console.warn("⚠️ Clé API GeoDB absente. Vérifie ton fichier .env.local");
  }

  const handleCalendarClick = () => setIsOpen(!isOpen);
  const togglePassengerDropdown = () => setIsPassengerOpen(!isPassengerOpen);
  const incrementPassenger = () => setPassengerCount((prev) => prev + 1);
  const decrementPassenger = () => setPassengerCount((prev) => (prev > 1 ? prev - 1 : 1));

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

  const handleSubmit = (e) => {
    e.preventDefault();
    const searchData = {
      departure,
      destination,
      date: startDate,
      passengers: passengerCount,
    };
    console.log("Données de recherche :", searchData);
  };

  return (
    <form role="search" onSubmit={handleSubmit} className="search">
      <div className="search-contenant">

        {/* Départ */}
        <div className="depart" style={{ position: "relative" }}>
        <svg xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" width="40" height="41" viewBox="0 0 40 41" fill="none">
        <rect width="40" height="41" fill="#F5F5F5"/>
        <rect width="1440" height="2409" transform="translate(-243 -566)" fill="#000A27"/>
        <path d="M1197 -408H-243V21H1197V-408Z" fill="url(#pattern0_1081_2)"/>
        <rect x="-30" y="-15" width="1014" height="70.5047" rx="12.675" fill="white"/>
        <path d="M25.3541 35.1058C25.748 35.1058 26.1258 34.9493 26.4044 34.6708C26.683 34.3922 26.8395 34.0144 26.8395 33.6205C26.8395 33.2265 26.683 32.8487 26.4044 32.5702C26.1258 32.2916 25.748 32.1351 25.3541 32.1351H12.9762C11.9257 32.1351 10.9182 31.7178 10.1754 30.975C9.43255 30.2322 9.01524 29.2247 9.01524 28.1742V12.3304C9.01524 11.2799 9.43255 10.2725 10.1754 9.52964C10.9182 8.78682 11.9257 8.36951 12.9762 8.36951H25.3541C25.748 8.36951 26.1258 8.21302 26.4044 7.93446C26.683 7.6559 26.8395 7.2781 26.8395 6.88416C26.8395 6.49022 26.683 6.11241 26.4044 5.83385C26.1258 5.5553 25.748 5.3988 25.3541 5.3988H12.9762C11.1378 5.3988 9.3747 6.1291 8.07476 7.42903C6.77483 8.72897 6.04453 10.4921 6.04453 12.3304V28.1742C6.04453 30.0126 6.77483 31.7757 8.07476 33.0756C9.3747 34.3755 11.1378 35.1058 12.9762 35.1058H25.3541ZM27.3167 12.7246C27.46 12.5921 27.628 12.4893 27.8111 12.4218C27.9941 12.3543 28.1887 12.3235 28.3836 12.3313C28.5786 12.339 28.7701 12.385 28.9472 12.4668C29.1244 12.5486 29.2837 12.6644 29.416 12.8077L35.3575 19.2443C35.6111 19.5187 35.7519 19.8786 35.7519 20.2523C35.7519 20.626 35.6111 20.9859 35.3575 21.2604L29.416 27.6969C29.1484 27.9861 28.7769 28.1571 28.3832 28.1723C27.9895 28.1875 27.6059 28.0457 27.3167 27.7781C27.0276 27.5105 26.8566 27.139 26.8414 26.7453C26.8261 26.3516 26.9679 25.968 27.2355 25.6788L30.8757 21.7357H15.4518C15.0578 21.7357 14.68 21.5792 14.4015 21.3006C14.1229 21.0221 13.9664 20.6443 13.9664 20.2503C13.9664 19.8564 14.1229 19.4786 14.4015 19.2C14.68 18.9215 15.0578 18.765 15.4518 18.765H30.8737L27.2336 14.8219C27.1012 14.6786 26.9983 14.5106 26.9308 14.3276C26.8633 14.1445 26.8326 13.9499 26.8403 13.755C26.848 13.56 26.8941 13.3685 26.9758 13.1914C27.0576 13.0142 27.1734 12.8569 27.3167 12.7246Z" fill="#474C5A"/>
        <defs>
        <pattern id="pattern0_1081_2" patternContentUnits="objectBoundingBox" width="1" height="1">
        <use xlink:href="#image0_1081_2" transform="matrix(0.00024542 0 0 0.000979742 0.000179894 -0.373871)"/>
        </pattern>
        </defs>
        </svg>
          <input
            className="depart-input"
            placeholder="Départ"
            name="departure"
            value={departure}
            onChange={(e) =>
              handleAutocomplete(e.target.value, setDeparture, setDepartureSuggestions)
            }
            required
            autoComplete="off"
          />
          {departureSuggestions.length > 0 && (
            <ul className="suggestions-list">
              {departureSuggestions.map((ville, i) => (
                <li
                  key={i}
                  onClick={() => {
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
        <div className="destination" style={{ position: "relative" }}>
        <svg xmlns="http://www.w3.org/2000/svg" width="34" height="31" viewBox="0 0 34 31" fill="none">
        <path d="M14.2299 30.1058C13.836 30.1058 13.4581 29.9493 13.1796 29.6708C12.901 29.3922 12.7445 29.0144 12.7445 28.6205C12.7445 28.2265 12.901 27.8487 13.1796 27.5702C13.4581 27.2916 13.836 27.1351 14.2299 27.1351H26.6078C27.6583 27.1351 28.6658 26.7178 29.4086 25.975C30.1514 25.2322 30.5688 24.2247 30.5688 23.1742V7.33044C30.5688 6.27994 30.1514 5.27246 29.4086 4.52964C28.6658 3.78682 27.6583 3.36951 26.6078 3.36951H14.2299C13.836 3.36951 13.4581 3.21302 13.1796 2.93446C12.901 2.6559 12.7445 2.2781 12.7445 1.88416C12.7445 1.49022 12.901 1.11241 13.1796 0.833853C13.4581 0.555295 13.836 0.398804 14.2299 0.398804H26.6078C28.4462 0.398804 30.2093 1.1291 31.5092 2.42903C32.8092 3.72897 33.5395 5.49206 33.5395 7.33044V23.1742C33.5395 25.0126 32.8092 26.7757 31.5092 28.0756C30.2093 29.3755 28.4462 30.1058 26.6078 30.1058H14.2299ZM14.2121 7.72456C14.3554 7.59215 14.5233 7.48926 14.7064 7.42178C14.8894 7.3543 15.084 7.32355 15.2789 7.33127C15.4739 7.33899 15.6654 7.38505 15.8426 7.4668C16.0197 7.54856 16.179 7.66441 16.3114 7.80774L22.2528 14.2443C22.5064 14.5187 22.6472 14.8786 22.6472 15.2523C22.6472 15.626 22.5064 15.9859 22.2528 16.2604L16.3114 22.6969C16.1789 22.8401 16.0194 22.9557 15.8422 23.0373C15.665 23.1189 15.4735 23.1647 15.2785 23.1723C15.0836 23.1798 14.8891 23.1489 14.7061 23.0813C14.5231 23.0136 14.3552 22.9106 14.2121 22.7781C14.0689 22.6456 13.9532 22.4862 13.8717 22.309C13.7901 22.1318 13.7442 21.9402 13.7367 21.7453C13.7215 21.3516 13.8632 20.968 14.1309 20.6788L17.771 16.7357H2.34708C1.95314 16.7357 1.57533 16.5792 1.29677 16.3006C1.01822 16.0221 0.861725 15.6443 0.861725 15.2503C0.861725 14.8564 1.01822 14.4786 1.29677 14.2C1.57533 13.9215 1.95314 13.765 2.34708 13.765H17.769L14.1289 9.82385C13.9965 9.68057 13.8936 9.5126 13.8261 9.32954C13.7586 9.14648 13.7279 8.95192 13.7356 8.75698C13.7433 8.56203 13.7894 8.37051 13.8711 8.19337C13.9529 8.01622 14.0687 7.85692 14.2121 7.72456Z" fill="#474C5A"/>
        </svg>
          <input
            className="destination-input"
            placeholder="Destination"
            name="destination"
            value={destination}
            onChange={(e) =>
              handleAutocomplete(e.target.value, setDestination, setDestinationSuggestions)
            }
            required
            autoComplete="off"
          />
          {destinationSuggestions.length > 0 && (
            <ul className="suggestions-list">
              {destinationSuggestions.map((ville, i) => (
                <li
                  key={i}
                  onClick={() => {
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

        {/* Date */}
        <button className="btn-calendar" onClick={handleCalendarClick} type="button">
          <svg xmlns="http://www.w3.org/2000/svg" width="30" height="30" viewBox="0 0 30 30" fill="none">
          <path d="M24.375 4.6875H5.625C4.0717 4.6875 2.8125 5.9467 2.8125 7.5V24.375C2.8125 25.9283 4.0717 27.1875 5.625 27.1875H24.375C25.9283 27.1875 27.1875 25.9283 27.1875 24.375V7.5C27.1875 5.9467 25.9283 4.6875 24.375 4.6875Z" stroke="black" stroke-linejoin="round"/>
          <path d="M17.3438 15C18.1204 15 18.75 14.3704 18.75 13.5938C18.75 12.8171 18.1204 12.1875 17.3438 12.1875C16.5671 12.1875 15.9375 12.8171 15.9375 13.5938C15.9375 14.3704 16.5671 15 17.3438 15Z" fill="black"/>
          <path d="M22.0312 15C22.8079 15 23.4375 14.3704 23.4375 13.5938C23.4375 12.8171 22.8079 12.1875 22.0312 12.1875C21.2546 12.1875 20.625 12.8171 20.625 13.5938C20.625 14.3704 21.2546 15 22.0312 15Z" fill="black"/>
          <path d="M17.3438 19.6875C18.1204 19.6875 18.75 19.0579 18.75 18.2812C18.75 17.5046 18.1204 16.875 17.3438 16.875C16.5671 16.875 15.9375 17.5046 15.9375 18.2812C15.9375 19.0579 16.5671 19.6875 17.3438 19.6875Z" fill="black"/>
          <path d="M22.0312 19.6875C22.8079 19.6875 23.4375 19.0579 23.4375 18.2812C23.4375 17.5046 22.8079 16.875 22.0312 16.875C21.2546 16.875 20.625 17.5046 20.625 18.2812C20.625 19.0579 21.2546 19.6875 22.0312 19.6875Z" fill="black"/>
          <path d="M7.96875 19.6875C8.7454 19.6875 9.375 19.0579 9.375 18.2812C9.375 17.5046 8.7454 16.875 7.96875 16.875C7.1921 16.875 6.5625 17.5046 6.5625 18.2812C6.5625 19.0579 7.1921 19.6875 7.96875 19.6875Z" fill="black"/>
          <path d="M12.6562 19.6875C13.4329 19.6875 14.0625 19.0579 14.0625 18.2812C14.0625 17.5046 13.4329 16.875 12.6562 16.875C11.8796 16.875 11.25 17.5046 11.25 18.2812C11.25 19.0579 11.8796 19.6875 12.6562 19.6875Z" fill="black"/>
          <path d="M7.96875 24.375C8.7454 24.375 9.375 23.7454 9.375 22.9688C9.375 22.1921 8.7454 21.5625 7.96875 21.5625C7.1921 21.5625 6.5625 22.1921 6.5625 22.9688C6.5625 23.7454 7.1921 24.375 7.96875 24.375Z" fill="black"/>
          <path d="M12.6562 24.375C13.4329 24.375 14.0625 23.7454 14.0625 22.9688C14.0625 22.1921 13.4329 21.5625 12.6562 21.5625C11.8796 21.5625 11.25 22.1921 11.25 22.9688C11.25 23.7454 11.8796 24.375 12.6562 24.375Z" fill="black"/>
          <path d="M17.3438 24.375C18.1204 24.375 18.75 23.7454 18.75 22.9688C18.75 22.1921 18.1204 21.5625 17.3438 21.5625C16.5671 21.5625 15.9375 22.1921 15.9375 22.9688C15.9375 23.7454 16.5671 24.375 17.3438 24.375Z" fill="black"/>
          <path d="M7.5 2.8125V4.6875M22.5 2.8125V4.6875" stroke="black" stroke-linecap="round" stroke-linejoin="round"/>
          <path d="M27.1875 9.375H2.8125" stroke="black" stroke-linejoin="round"/>
          </svg>
          {startDate ? startDate.toLocaleDateString() : "Choisir une date"}
        </button>
        {isOpen && (
          <div style={{ position: "absolute", zIndex: 10 }}>
            <DatePicker
              selected={startDate}
              onChange={(date) => {
                setStartDate(date);
                setIsOpen(false);
              }}
              minDate={new Date()}
              inline
            />
          </div>
        )}

        {/* Passagers */}
        <div className="passager">
          <button  className="personn" type="button" onClick={togglePassengerDropdown}>
          <svg xmlns="http://www.w3.org/2000/svg" width="30" height="30" viewBox="0 0 30 30" fill="none">
          <g id="icon-park-outline:avatar">
<path id="Vector" d="M3.1275 26.3944C3.12839 26.4584 3.14189 26.5217 3.16723 26.5805C3.19256 26.6393 3.22922 26.6925 3.27513 26.7371C3.32104 26.7818 3.37529 26.8169 3.43478 26.8406C3.49428 26.8642 3.55785 26.876 3.62187 26.8751H26.3762C26.4403 26.876 26.504 26.8644 26.5635 26.8408C26.6231 26.8171 26.6774 26.782 26.7234 26.7374C26.7694 26.6927 26.8061 26.6395 26.8315 26.5806C26.8568 26.5218 26.8704 26.4585 26.8712 26.3944V25.8207C26.8825 25.6476 26.9056 24.7851 26.3369 23.8307C25.9781 23.2288 25.4575 22.7094 24.7894 22.2857C23.9812 21.7732 22.9531 21.4026 21.7094 21.1794C21.078 21.0908 20.4517 20.969 19.8331 20.8144C18.1881 20.3944 18.0444 20.0226 18.0431 20.0188C18.0334 19.9821 18.0196 19.9467 18.0019 19.9132C17.9881 19.8444 17.955 19.5832 18.0187 18.8838C18.18 17.1069 19.1331 16.0569 19.8987 15.2132C20.14 14.9476 20.3681 14.6957 20.5437 14.4494C21.3019 13.3869 21.3719 12.1776 21.375 12.1026C21.3779 11.9697 21.3595 11.8372 21.3206 11.7101C21.2456 11.4788 21.1062 11.3351 21.0037 11.2288C20.9795 11.2045 20.956 11.1794 20.9331 11.1538C20.9256 11.1451 20.9056 11.1213 20.9237 11.0019C20.985 10.6174 21.0274 10.23 21.0506 9.8413C21.0856 9.21505 21.1125 8.2788 20.9506 7.36693C20.9269 7.19275 20.891 7.02045 20.8431 6.8513C20.6731 6.22339 20.3981 5.68797 20.0181 5.24505C19.9525 5.17318 18.36 3.49505 13.7369 3.1513C13.0975 3.1038 12.4656 3.12943 11.8431 3.1613C11.659 3.16544 11.4758 3.18805 11.2962 3.2288C10.8187 3.35193 10.6912 3.65443 10.6581 3.8238C10.6025 4.10505 10.7 4.32255 10.7644 4.46755C10.7737 4.48818 10.7856 4.5138 10.765 4.5813C10.6581 4.74755 10.4887 4.89755 10.3169 5.03943C10.2669 5.0813 9.10812 6.0813 9.04437 7.38693C8.8725 8.38005 8.885 9.92693 9.08812 10.9963C9.10062 11.0557 9.1175 11.1432 9.08937 11.2026C8.87062 11.3982 8.62312 11.6201 8.62375 12.1263C8.62625 12.1776 8.69687 13.3863 9.455 14.4494C9.63 14.6957 9.85812 14.9469 10.0987 15.2126L10.1 15.2132C10.8656 16.0569 11.8187 17.1069 11.98 18.8832C12.0431 19.5832 12.01 19.8438 11.9969 19.9132C11.9789 19.9467 11.9649 19.9821 11.955 20.0188C11.9544 20.0226 11.8112 20.3932 10.1737 20.8126C9.22875 21.0544 8.29875 21.1782 8.27062 21.1813C7.06187 21.3857 6.04 21.7476 5.23312 22.2569C4.5675 22.6776 4.04562 23.1988 3.68312 23.8051C3.10312 24.7738 3.11875 25.6563 3.12687 25.8176L3.1275 26.3944Z" stroke="#1B998B" stroke-width="2" stroke-linejoin="round"/>
          </g>
          </svg>
            {passengerCount} Passager{passengerCount > 1 ? "s" : ""}
          </button>
          {isPassengerOpen && (
            <div className="passenger-dropdown">
              <button type="button" onClick={decrementPassenger}>-</button>
              <span>{passengerCount}</span>
              <button type="button" onClick={incrementPassenger}>+</button>
            </div>
          )}
        </div>

        {/* Rechercher */}
        <button type="submit" className="btn-search">Rechercher</button>
      </div>
    </form>
  );
}

export default SearchBar;
