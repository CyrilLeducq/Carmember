import { useState, useRef } from 'react';
import DatePicker from 'react-datepicker';
import 'react-datepicker/dist/react-datepicker.css';
import { registerLocale } from 'react-datepicker';
import fr from 'date-fns/locale/fr';
import '../FormRegistration/FormRegistration.css';
import { Link } from "react-router-dom";


registerLocale('fr', fr);

function FormRegistration() {
  const formRef = useRef();
  const [erreur, setErreur] = useState('');

  const [formData, setFormData] = useState({
    lastName: '',
    firstName: '',
    genre: '',
    birthdate: '',
    email: '',
    password: ''
  });

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData(prev => ({
      ...prev,
      [name]: value
    }));
  };

  const handleDateChange = (date) => {
    setFormData(prev => ({
      ...prev,
      birthdate: date
    }));
  };

  const calculerAge = (date) => {
    const dateNaissance = new Date(date);
    const aujourdHui = new Date();
    let age = aujourdHui.getFullYear() - dateNaissance.getFullYear();
    const m = aujourdHui.getMonth() - dateNaissance.getMonth();
    if (m < 0 || (m === 0 && aujourdHui.getDate() < dateNaissance.getDate())) {
      age--;
    }
    return age;
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    const form = formRef.current;
  
    if (form && form.checkValidity()) {
      const age = calculerAge(formData.birthdate);
      if (age < 18) {
        setErreur("Tu n'es pas majeur.");
        return;
      } else {
        setErreur('');
      }
  
      try {
        const response = await fetch("http://localhost:5104", {
          method: "POST",
          headers: {
            "Content-Type": "application/json",
          },
          body: JSON.stringify({
            ...formData,
            birthdate: formData.birthdate.toISOString().split("T")[0], 
          }),
        });
  
        if (!response.ok) throw new Error("Erreur côté serveur");
  
        const data = await response.json();
        console.log("Utilisateur inscrit :", data);
        alert("Inscription réussie !");
  
      } catch (err) {
        console.error("Erreur API :", err);
        alert("Erreur lors de l'inscription, réessaie plus tard.");
      }
    } else {
      form.reportValidity();
    }
  };

  return (
    <div className='contenant'>
      <form ref={formRef} onSubmit={handleSubmit}>
        <div className="name">
          <input className="form-control" id="firstName" name="firstName" value={formData.firstName}
            onChange={handleChange} required placeholder='Prénom' />
          <input className="form-control" id="lastName" name="lastName" value={formData.lastName} onChange={handleChange}
            required placeholder='Nom' />
        </div>
        <div className="genre-anniv">
          <DatePicker
            selected={formData.birthdate}
            onChange={handleDateChange}
            locale="fr"
            placeholderText="Anniversaire"
            className="form-control"
            dateFormat="dd/MM/yyyy"
            maxDate={new Date()}
            showMonthDropdown
            showYearDropdown
            dropdownMode="select"
            name="birthdate"
            required
          />

          <select className="form-control" name="gender" value={formData.genre} onChange={handleChange} required>
            <option value="">Genre</option>
            <option value="man">Homme</option>
            <option value="woman">Femme</option>
            <option value="other">Autre</option>
          </select>
        </div>

        {erreur && <p style={{ color: 'red' }}>{erreur}</p>}

        <input type="email" className="email-sub" id="inputEmail" name="email" value={formData.email}
          onChange={handleChange} placeholder='Email' required />

        <input type="password" className="password-sub" id="inputPassword" name="password" value={formData.password}
          onChange={handleChange} placeholder='Mot de passe' required
          pattern="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\w\s]).{8,}$"
          title="Le mot de passe doit contenir au moins 8 caractères, une majuscule, une minuscule, un chiffre et un caractère spécial." />

        <label className="form-check-label">
          <input type="checkbox" name="newsletter" className="form-check-input" /> J'accepte de recevoir la newsletter
        </label>

        <span className='question'>Déjà inscrit(e)?</span>

        <div className="btn-group">
          <button  className="submit-connex"><Link to="/Connexion">Connexion</Link></button>
          <button type="submit" className="submit-envoi">Valider</button>
        </div>
      </form>
    </div>
  );
}

export default FormRegistration;
