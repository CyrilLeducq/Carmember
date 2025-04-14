import { useState } from "react";
import "../CarSelect/carSelect.css"

const categories = {
  Voiture: [
    "Chèvraulait", "Fetaxi", "Goudacia", "Maroille's'Royce",
    "Munsterati", "Roqueford", "Bleu-M-W", "Pecorinaudi", "Le P'tit Cabriaulait"
  ],
  Autres: [
    "Brie-Cyclette", "Munster-Truck", "Motomme du Jura", "Mont des Cats'Mion",
    "Side-Carbécou", "Pavé d'Affinavion", "Pénichabichou", "Voilivarot",
    "Comtéléphérique", "Carmembert"
  ],
};

function CarSelect() {
  const [categorie, setCategorie] = useState("");
  const [sousCategorie, setSousCategorie] = useState("");
  const [vehicules, setVehicules] = useState([]);
  const [formVisible, setFormVisible] = useState(false);

  const handleCategorieChange = (e) => {
    setCategorie(e.target.value);
    setSousCategorie("");
  };

  const handleAddVehicule = () => {
    if (categorie && sousCategorie) {
      setVehicules((prev) => [...prev, { categorie, type: sousCategorie }]);
      setCategorie("");
      setSousCategorie("");
      setFormVisible(false);
    }
  };

  const handleDeleteVehicule = (indexToDelete) => {
    setVehicules((prev) => prev.filter((_, index) => index !== indexToDelete));
  };
  const handleSubmitVehicules = async () => {
  if (vehicules.length === 0) {
    alert("Ajoute au moins un véhicule !");
    return;
  }

  try {
    const response = await fetch("http://localhost/", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({ vehicules }),
    });

    if (!response.ok) throw new Error("Erreur lors de l'envoi des véhicules");

    const data = await response.json();
    console.log("Véhicules envoyés avec succès :", data);
    alert("Véhicules enregistrés !");
  } catch (err) {
    console.error("Erreur API :", err);
    alert("Une erreur est survenue");
  }
};


  return (
    <div className="vehicule-container">
        <div className="vehicule-action">
            <span className="vehicule-icon">
                <svg xmlns="http://www.w3.org/2000/svg" width="30" height="30" viewBox="0 0 30 30" fill="none">
                <g id="Icone Voiture">
                <path id="Vector" d="M28.125 13.125H24.7629L19.6875 8.04962C19.514 7.87475 19.3075 7.73611 19.08 7.64176C18.8524 7.54741 18.6084 7.49922 18.3621 7.50001H5.18906C4.88109 7.50058 4.57799 7.577 4.30657 7.72253C4.03514 7.86805 3.80374 8.07819 3.63281 8.33438L0.157031 13.5422C0.0549045 13.6965 0.000305693 13.8774 0 14.0625L0 19.6875C0 20.1848 0.197544 20.6617 0.549175 21.0133C0.900805 21.365 1.37772 21.5625 1.875 21.5625H3.86719C4.07372 22.3691 4.54284 23.0841 5.2006 23.5947C5.85836 24.1052 6.66734 24.3824 7.5 24.3824C8.33266 24.3824 9.14164 24.1052 9.7994 23.5947C10.4572 23.0841 10.9263 22.3691 11.1328 21.5625H18.8672C19.0737 22.3691 19.5428 23.0841 20.2006 23.5947C20.8584 24.1052 21.6673 24.3824 22.5 24.3824C23.3327 24.3824 24.1416 24.1052 24.7994 23.5947C25.4572 23.0841 25.9263 22.3691 26.1328 21.5625H28.125C28.6223 21.5625 29.0992 21.365 29.4508 21.0133C29.8025 20.6617 30 20.1848 30 19.6875V15C30 14.5027 29.8025 14.0258 29.4508 13.6742C29.0992 13.3226 28.6223 13.125 28.125 13.125ZM5.18906 9.37501H18.3621L22.1121 13.125H2.69531L5.18906 9.37501ZM7.5 22.5C7.12916 22.5 6.76665 22.39 6.45831 22.184C6.14996 21.978 5.90964 21.6852 5.76773 21.3425C5.62581 20.9999 5.58868 20.6229 5.66103 20.2592C5.73337 19.8955 5.91195 19.5614 6.17417 19.2992C6.4364 19.037 6.77049 18.8584 7.13421 18.786C7.49792 18.7137 7.87492 18.7508 8.21753 18.8927C8.56014 19.0347 8.85298 19.275 9.05901 19.5833C9.26503 19.8917 9.375 20.2542 9.375 20.625C9.375 21.1223 9.17746 21.5992 8.82582 21.9508C8.47419 22.3025 7.99728 22.5 7.5 22.5ZM22.5 22.5C22.1292 22.5 21.7666 22.39 21.4583 22.184C21.15 21.978 20.9096 21.6852 20.7677 21.3425C20.6258 20.9999 20.5887 20.6229 20.661 20.2592C20.7334 19.8955 20.912 19.5614 21.1742 19.2992C21.4364 19.037 21.7705 18.8584 22.1342 18.786C22.4979 18.7137 22.8749 18.7508 23.2175 18.8927C23.5601 19.0347 23.853 19.275 24.059 19.5833C24.265 19.8917 24.375 20.2542 24.375 20.625C24.375 21.1223 24.1775 21.5992 23.8258 21.9508C23.4742 22.3025 22.9973 22.5 22.5 22.5Z" fill="#F5C45C"/>
                </g>
                </svg>
            </span>
            <span className="vehicule-label">Ajouter mon véhicule</span>
            <button className="vehicule-button" onClick={() => setFormVisible(true)}><svg xmlns="http://www.w3.org/2000/svg" width="30" height="31" viewBox="0 0 30 31" fill="none">
                <g id="Icone plus fond plein">
                <path id="Vector" d="M15 0.5C18.9782 0.5 22.7936 2.08035 25.6066 4.8934C28.4196 7.70644 30 11.5218 30 15.5C30 19.4782 28.4196 23.2936 25.6066 26.1066C22.7936 28.9196 18.9782 30.5 15 30.5C11.0218 30.5 7.20644 28.9196 4.3934 26.1066C1.58035 23.2936 0 19.4782 0 15.5C0 11.5218 1.58035 7.70644 4.3934 4.8934C7.20644 2.08035 11.0218 0.5 15 0.5ZM16.9913 8.585C16.9913 8.08772 16.7937 7.61081 16.4421 7.25917C16.0904 6.90754 15.6135 6.71 15.1163 6.71C14.619 6.71 14.1421 6.90754 13.7904 7.25917C13.4388 7.61081 13.2413 8.08772 13.2413 8.585V13.7413H8.085C7.58772 13.7413 7.11081 13.9388 6.75917 14.2904C6.40754 14.6421 6.21 15.119 6.21 15.6163C6.21 16.1135 6.40754 16.5904 6.75917 16.9421C7.11081 17.2937 7.58772 17.4913 8.085 17.4913H13.2413V22.6475C13.2413 23.1448 13.4388 23.6217 13.7904 23.9733C14.1421 24.325 14.619 24.5225 15.1163 24.5225C15.6135 24.5225 16.0904 24.325 16.4421 23.9733C16.7937 23.6217 16.9913 23.1448 16.9913 22.6475V17.4913H22.1475C22.6448 17.4913 23.1217 17.2937 23.4733 16.9421C23.825 16.5904 24.0225 16.1135 24.0225 15.6163C24.0225 15.119 23.825 14.6421 23.4733 14.2904C23.1217 13.9388 22.6448 13.7413 22.1475 13.7413H16.9913V8.585Z" fill="#1B998B"/>
                </g>
                </svg>
            </button>
      </div>

      {formVisible && (
        <div className="vehicule-selects">
          <label>
            Catégorie :
            <select value={categorie} onChange={handleCategorieChange}>
              <option value="">-- Choisir une catégorie --</option>
              {Object.keys(categories).map((cat) => (
                <option key={cat} value={cat}>{cat}</option>
              ))}
            </select>
          </label>

          {categorie && (
            <label>
              Type :
              <select
                value={sousCategorie}
                onChange={(e) => setSousCategorie(e.target.value)}
              >
                <option value="">-- Choisir un type --</option>
                {categories[categorie].map((type) => (
                  <option key={type} value={type}>{type}</option>
                ))}
              </select>
            </label>
          )}

          <button
            className="vehicule-button-submit"
            onClick={handleAddVehicule}
            disabled={!categorie || !sousCategorie}
          >
            Valider
          </button>
        </div>
      )}

      {vehicules.length > 0 && (
        <div className="vehicule-liste">
          <h3 className="vehicule-sous-titre">Mes véhicules ajoutés :</h3>
            {vehicules.map((v, index) => (
              <li key={index} className="vehicule-item">
                <span> <svg xmlns="http://www.w3.org/2000/svg" width="30" height="30" viewBox="0 0 30 30" fill="none">
                <g id="Icone Voiture">
                <path id="Vector" d="M28.125 13.125H24.7629L19.6875 8.04962C19.514 7.87475 19.3075 7.73611 19.08 7.64176C18.8524 7.54741 18.6084 7.49922 18.3621 7.50001H5.18906C4.88109 7.50058 4.57799 7.577 4.30657 7.72253C4.03514 7.86805 3.80374 8.07819 3.63281 8.33438L0.157031 13.5422C0.0549045 13.6965 0.000305693 13.8774 0 14.0625L0 19.6875C0 20.1848 0.197544 20.6617 0.549175 21.0133C0.900805 21.365 1.37772 21.5625 1.875 21.5625H3.86719C4.07372 22.3691 4.54284 23.0841 5.2006 23.5947C5.85836 24.1052 6.66734 24.3824 7.5 24.3824C8.33266 24.3824 9.14164 24.1052 9.7994 23.5947C10.4572 23.0841 10.9263 22.3691 11.1328 21.5625H18.8672C19.0737 22.3691 19.5428 23.0841 20.2006 23.5947C20.8584 24.1052 21.6673 24.3824 22.5 24.3824C23.3327 24.3824 24.1416 24.1052 24.7994 23.5947C25.4572 23.0841 25.9263 22.3691 26.1328 21.5625H28.125C28.6223 21.5625 29.0992 21.365 29.4508 21.0133C29.8025 20.6617 30 20.1848 30 19.6875V15C30 14.5027 29.8025 14.0258 29.4508 13.6742C29.0992 13.3226 28.6223 13.125 28.125 13.125ZM5.18906 9.37501H18.3621L22.1121 13.125H2.69531L5.18906 9.37501ZM7.5 22.5C7.12916 22.5 6.76665 22.39 6.45831 22.184C6.14996 21.978 5.90964 21.6852 5.76773 21.3425C5.62581 20.9999 5.58868 20.6229 5.66103 20.2592C5.73337 19.8955 5.91195 19.5614 6.17417 19.2992C6.4364 19.037 6.77049 18.8584 7.13421 18.786C7.49792 18.7137 7.87492 18.7508 8.21753 18.8927C8.56014 19.0347 8.85298 19.275 9.05901 19.5833C9.26503 19.8917 9.375 20.2542 9.375 20.625C9.375 21.1223 9.17746 21.5992 8.82582 21.9508C8.47419 22.3025 7.99728 22.5 7.5 22.5ZM22.5 22.5C22.1292 22.5 21.7666 22.39 21.4583 22.184C21.15 21.978 20.9096 21.6852 20.7677 21.3425C20.6258 20.9999 20.5887 20.6229 20.661 20.2592C20.7334 19.8955 20.912 19.5614 21.1742 19.2992C21.4364 19.037 21.7705 18.8584 22.1342 18.786C22.4979 18.7137 22.8749 18.7508 23.2175 18.8927C23.5601 19.0347 23.853 19.275 24.059 19.5833C24.265 19.8917 24.375 20.2542 24.375 20.625C24.375 21.1223 24.1775 21.5992 23.8258 21.9508C23.4742 22.3025 22.9973 22.5 22.5 22.5Z" fill="#F5C45C"/>
                </g>
                </svg></span> {v.categorie}{v.type}
                <button className="vehicule-delete" onClick={() => handleDeleteVehicule(index)} title="Supprimer">
                  ❌
                </button>
              </li>
            ))}
        </div>
      )}
    </div>
  );
}
export default CarSelect
