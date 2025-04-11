import React, { useState } from "react";
import "../CheeseSelect/cheeseSelect.css"

const cheeses = [
  "Appenzeller",
  "Asiago AOP",
  "Beaufort AOP",
  "Bleu de Gex AOP",
  "Boulette d’Avesnes",
  "Brie de Meaux AOP",
  "Burrata",
  "Camembert AOP",
  "Cantal AOP",
  "Chaource AOP",
  "Cheddar",
  "Comté AOP",
  "Edam",
  "Emmental Suisse",
  "Epoisses AOP",
  "Feta AOP",
  "Gruyère suisse",
  "Langres AOP",
  "Livarot AOP",
  "Maroilles AOP",
  "Mimolette",
  "Mont d'Or AOP",
  "Morbier AOP",
  "Munster AOP",
  "Neufchâtel AOP",
  "Parmesan AOP",
  "Pont-l'Evêque AOP",
  "Raclette",
  "Reblochon AOP",
  "Roquefort AOP",
  "Saint-Félicien",
  "Saint-Marcellin IGP",
  "Saint-Nectaire AOP",
  "Stilton AOP",
  "Taleggio AOP",
  "Tête de moine",
  "Tome des Bauges AOP",
  "Tomme de Savoie IGP",
  "Tomme du Jura",
  "Vieux-Lille",
];

const CheeseSelect = () => {
  const [selectedCheese, setSelectedCheese] = useState("");

  const handleChange = (e) => {
    setSelectedCheese(e.target.value);
    console.log("Fromage sélectionné :", e.target.value);
  };

  return (
    
      <select
        id="cheese-select"
        value={selectedCheese}
        onChange={handleChange}
      >
        <option value="">Choisir</option>
        {cheeses.map((cheese) => (
          <option key={cheese} value={cheese}>
            {cheese}
          </option>
        ))}
      </select>
  );
};

export default CheeseSelect;
