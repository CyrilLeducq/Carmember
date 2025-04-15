import React, { useState } from 'react';
import './TrajetsTable.css';

const initialTrajets = [
  {
    idTrajet: '001',
    idUtilisateur: '0003',
    datePublication: '01/01/2001',
    adresseDepart: '19 rue Malmaison',
    villeDepart: 'Toulon',
    adresseDestination: '720 rue blablabla',
    villeDestination: 'Lille',
    dateTrajet: '30/04/25',
    places: '2',
    statut: 'En cours',
  },
  {
    idTrajet: '002',
    idUtilisateur: '0003',
    datePublication: '01/01/2001',
    adresseDepart: '19 rue Malmaison',
    villeDepart: 'Toulon',
    adresseDestination: '720 rue blablabla',
    villeDestination: 'Lille',
    dateTrajet: '30/04/25',
    places: '2',
    statut: 'Annulé',
  },
  {
    idTrajet: '003',
    idUtilisateur: '0003',
    datePublication: '01/01/2001',
    adresseDepart: '19 rue Malmaison',
    villeDepart: 'Toulon',
    adresseDestination: '720 rue blablabla',
    villeDestination: 'Lille',
    dateTrajet: '30/04/25',
    places: 'Complet',
    statut: 'En cours',
  },
];
function TrajetsTable() {
  const [trajets, setTrajets] = useState(initialTrajets);
  const [editIndex, setEditIndex] = useState(null);
  const [editedTrajet, setEditedTrajet] = useState({});

  const handleDelete = (index) => {
    const updated = [...trajets];
    updated.splice(index, 1);
    setTrajets(updated);
  };

  const handleEdit = (index) => {
    setEditIndex(index);
    setEditedTrajet(trajets[index]);
  };

  const handleChange = (e, key) => {
    setEditedTrajet({ ...editedTrajet, [key]: e.target.value });
  };

  const handleSave = () => {
    const updated = [...trajets];
    updated[editIndex] = editedTrajet;
    setTrajets(updated);
    setEditIndex(null);
  };

  const handleCancel = () => {
    setEditIndex(null);
    setEditedTrajet({});
  };

  return (
    <div className="table-container">
      <div className="header">
        <h2 className='header-title'><svg width="46" height="46" viewBox="0 0 46 46" fill="none" xmlns="http://www.w3.org/2000/svg">
<g id="Icone Here">
<path id="Vector" d="M21.0312 20.1875L19.7188 18.875C19.3438 18.5 18.9062 18.3125 18.4062 18.3125C17.9062 18.3125 17.4688 18.5 17.0938 18.875C16.7188 19.25 16.5312 19.6956 16.5312 20.2119C16.5312 20.7281 16.7188 21.1731 17.0938 21.5469L19.7188 24.2187C20.0938 24.5937 20.5312 24.7812 21.0312 24.7812C21.5312 24.7812 21.9687 24.5937 22.3437 24.2187L29 17.5625C29.375 17.1875 29.5625 16.7425 29.5625 16.2275C29.5625 15.7125 29.375 15.2669 29 14.8906C28.625 14.5144 28.18 14.3269 27.665 14.3281C27.15 14.3294 26.7044 14.5169 26.3281 14.8906L21.0312 20.1875ZM38 19.625C38 21.0312 37.7269 22.5081 37.1806 24.0556C36.6344 25.6031 35.8375 27.2119 34.79 28.8819C33.7425 30.5519 32.4375 32.2787 30.875 34.0625C29.3125 35.8462 27.5156 37.6744 25.4844 39.5469C25.1406 39.8594 24.75 40.0938 24.3125 40.25C23.875 40.4062 23.4375 40.4844 23 40.4844C22.5625 40.4844 22.125 40.4062 21.6875 40.25C21.25 40.0938 20.8594 39.8594 20.5156 39.5469C18.4844 37.6719 16.6875 35.8437 15.125 34.0625C13.5625 32.2812 12.2581 30.555 11.2119 28.8837C10.1656 27.2125 9.36875 25.6031 8.82125 24.0556C8.27375 22.5081 8 21.0312 8 19.625C8 14.9375 9.50813 11.2031 12.5244 8.42187C15.5406 5.64062 19.0325 4.25 23 4.25C26.9675 4.25 30.46 5.64062 33.4775 8.42187C36.495 11.2031 38.0025 14.9375 38 19.625Z" fill="white"/>
</g>
</svg>
 Trajets</h2>
        <input type="text" placeholder="Rechercher" className="search" />
      </div>
      <table className="trajet-table">
        <thead>
          <tr>
            <th># Id trajet</th>
            <th># Id Utilisateur</th>
            <th>Date de publication</th>
            <th>Adresse départ</th>
            <th>Ville départ</th>
            <th>Adresse destination</th>
            <th>Ville destination</th>
            <th>Date du trajet</th>
            <th>Places disponibles</th>
            <th>Statut trajet</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {trajets.map((trajet, index) => (
            <tr key={index}>
              {editIndex === index ? (
                <>
                  {Object.keys(trajet).map((key) => (
                    <td key={key}>
                      <input
                        value={editedTrajet[key]}
                        onChange={(e) => handleChange(e, key)}
                      />
                    </td>
                  ))}
                  <td className="actions">
                    <button onClick={handleSave}>✅</button>
                    <button onClick={handleCancel}>❌</button>
                  </td>
                </>
              ) : (
                <>
                  <td>{trajet.idTrajet}</td>
                  <td>{trajet.idUtilisateur}</td>
                  <td>{trajet.datePublication}</td>
                  <td>{trajet.adresseDepart}</td>
                  <td>{trajet.villeDepart}</td>
                  <td>{trajet.adresseDestination}</td>
                  <td>{trajet.villeDestination}</td>
                  <td>{trajet.dateTrajet}</td>
                  <td>{trajet.places}</td>
                  <td>{trajet.statut}</td>
                  <td className="actions">
                    <button className="edit-btn" onClick={() => handleEdit(index)}>✏️</button>
                    <button className="delete-btn" onClick={() => handleDelete(index)}>🗑️</button>
                  </td>
                </>
              )}
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}
export default TrajetsTable