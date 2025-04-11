import "../PhotoProfil/photoProfil.css"
import { useState } from "react";

function PhotoProfil() {
  const [profil, setProfil] = useState({
    photo: "https://i.postimg.cc/3xZmh8s1/images.png",
    username: "leslie_lobry",
  });

  const [editingField, setEditingField] = useState(null);

  const handleChange = (e) => {
    const { name, value } = e.target;
    setProfil((prev) => ({
      ...prev,
      [name]: value,
    }));
  };

  const handleEdit = (field) => {
    setEditingField(field);
  };

  const handleBlur = () => {
    setEditingField(null);
  };

  return (
    <div className="photo-profil">
      <div className="profile-picture">
        <img
          src={profil.photo}
          alt="Profil"
        />
        {editingField === "photo" ? (
          <input
            type="url"
            name="photo"
            value={profil.photo}
            onChange={handleChange}
            onBlur={handleBlur}
            autoFocus
          />
        ) : (
          <button className="edit-icon" onClick={() => handleEdit("photo")}>
            <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" viewBox="0 0 20 20" fill="none">
                <g id="Icone stylo">
                <path id="Vector" d="M9.40066 16.1601L16.7964 8.76441C15.5522 8.24465 14.4222 7.48565 13.4705 6.53049C12.5149 5.57857 11.7555 4.44821 11.2356 3.20361L3.83986 10.5993C3.26288 11.1763 2.97389 11.4653 2.7259 11.7833C2.4333 12.1588 2.18218 12.5648 1.97692 12.9943C1.80393 13.3582 1.67494 13.7462 1.41694 14.5202L0.0549935 18.6031C-0.00769048 18.79 -0.0169906 18.9907 0.0281383 19.1826C0.0732672 19.3746 0.171036 19.5501 0.310456 19.6895C0.449875 19.829 0.625418 19.9267 0.817353 19.9719C1.00929 20.017 1.21001 20.0077 1.39695 19.945L5.4798 18.5831C6.25477 18.3251 6.64176 18.1961 7.00574 18.0231C7.43706 17.8177 7.84071 17.5681 8.2167 17.2741C8.53469 17.0261 8.82368 16.7371 9.40066 16.1601ZM18.8483 6.71248C19.5857 5.97507 20 4.97493 20 3.93208C20 2.88923 19.5857 1.88909 18.8483 1.15168C18.1109 0.414272 17.1108 7.76986e-09 16.0679 0C15.0251 -7.76985e-09 14.0249 0.414272 13.2875 1.15168L12.4006 2.03865L12.4385 2.14964C12.8755 3.40038 13.5908 4.53555 14.5305 5.46953C15.4924 6.43731 16.6673 7.16671 17.9614 7.59945L18.8483 6.71248Z" fill="#1B998B"/>
                </g>
                </svg>
          </button>
        )}
      </div>

      <div className="username-section">
        {editingField === "username" ? (
          <input
            type="text"
            name="username"
            value={profil.username}
            onChange={handleChange}
            onBlur={handleBlur}
            autoFocus
          />
        ) : (
          <div className="username-display">
            <span>{profil.username}</span>
            <button className="edit-icon" onClick={() => handleEdit("username")}>
            <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" viewBox="0 0 20 20" fill="none">
                <g id="Icone stylo">
                <path id="Vector" d="M9.40066 16.1601L16.7964 8.76441C15.5522 8.24465 14.4222 7.48565 13.4705 6.53049C12.5149 5.57857 11.7555 4.44821 11.2356 3.20361L3.83986 10.5993C3.26288 11.1763 2.97389 11.4653 2.7259 11.7833C2.4333 12.1588 2.18218 12.5648 1.97692 12.9943C1.80393 13.3582 1.67494 13.7462 1.41694 14.5202L0.0549935 18.6031C-0.00769048 18.79 -0.0169906 18.9907 0.0281383 19.1826C0.0732672 19.3746 0.171036 19.5501 0.310456 19.6895C0.449875 19.829 0.625418 19.9267 0.817353 19.9719C1.00929 20.017 1.21001 20.0077 1.39695 19.945L5.4798 18.5831C6.25477 18.3251 6.64176 18.1961 7.00574 18.0231C7.43706 17.8177 7.84071 17.5681 8.2167 17.2741C8.53469 17.0261 8.82368 16.7371 9.40066 16.1601ZM18.8483 6.71248C19.5857 5.97507 20 4.97493 20 3.93208C20 2.88923 19.5857 1.88909 18.8483 1.15168C18.1109 0.414272 17.1108 7.76986e-09 16.0679 0C15.0251 -7.76985e-09 14.0249 0.414272 13.2875 1.15168L12.4006 2.03865L12.4385 2.14964C12.8755 3.40038 13.5908 4.53555 14.5305 5.46953C15.4924 6.43731 16.6673 7.16671 17.9614 7.59945L18.8483 6.71248Z" fill="#1B998B"/>
                </g>
                </svg>
            </button>
          </div>
        )}
      </div>
    </div>
  );
}

export default PhotoProfil;
