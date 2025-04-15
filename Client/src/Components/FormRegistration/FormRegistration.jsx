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
    firstName: '',
    lastName: '',
    email: '',
    password: '',
    gender: '',
    phoneNumber: '',
    profilePicture: '',
    birthdate: null
  });

  const handleChange = (e) => {
    const { name, value } = e.target;

    // Si c’est lastName, on force en MAJUSCULES
    setFormData(prev => ({
      ...prev,
      [name]: name === 'lastName' ? value.toUpperCase() : value
    }));
  };

  const handleDateChange = (date) => {
    setFormData(prev => ({
      ...prev,
      birthdate: date
    }));
  };

  const calculerAge = (date) => {
    if (!date) return 0;
    const naissance = new Date(date);
    const aujourdHui = new Date();
    let age = aujourdHui.getFullYear() - naissance.getFullYear();
    const m = aujourdHui.getMonth() - naissance.getMonth();
    if (m < 0 || (m === 0 && aujourdHui.getDate() < naissance.getDate())) {
      age--;
    }
    return age;
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    const form = formRef.current;

    if (form && form.checkValidity()) {
      if (!formData.birthdate) {
        setErreur("Tu dois renseigner ta date de naissance.");
        return;
      }

      const age = calculerAge(formData.birthdate);
      if (age < 18) {
        setErreur("Tu n'es pas majeur.");
        return;
      }

      // Validation locale du phoneNumber (ex: +33612345678)
      if (!/^\+([0-9]{1,4})[-. ]?([0-9]{1,4})[-. ]?([0-9]{1,4})[-. ]?([0-9]{1,4})?$/.test(formData.phoneNumber)) {
        setErreur("Numéro de téléphone invalide (ex: +33612345678)");
        return;
      }

      setErreur('');

      // Transformation du genre pour respecter le DTO
      let genreValide = '';
      switch (formData.gender) {
        case 'man':
          genreValide = 'Masculin';
          break;
        case 'woman':
          genreValide = 'Feminin';
          break;
        case 'other':
          genreValide = 'Autre';
          break;
        default:
          genreValide = '';
      }

      const payload = {
        firstName: formData.firstName,
        lastName: formData.lastName,
        email: formData.email,
        password: formData.password,
        gender: genreValide,
        phoneNumber: formData.phoneNumber,
        ...(formData.profilePicture.trim() !== '' && { profilePicture: formData.profilePicture })
      };
      

      console.log("Payload envoyé :", payload);

      try {
        const response = await fetch("http://localhost:5104/users", {
          method: "POST",
          headers: {
            "Content-Type": "application/json",
          },
          body: JSON.stringify(payload)
        });

        if (!response.ok) throw new Error("Erreur côté serveur");

        const data = await response.json();
        console.log("Utilisateur inscrit :", data);
        alert("Inscription réussie !");

        // Reset
        setFormData({
          firstName: '',
          lastName: '',
          email: '',
          password: '',
          gender: '',
          phoneNumber: '',
          profilePicture: '',
          birthdate: null
        });

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
          <input className="form-control" name="firstName" value={formData.firstName}
            onChange={handleChange} required placeholder='Prénom' />
          <input className="form-control" name="lastName" value={formData.lastName}
            onChange={handleChange} required placeholder='Nom (MAJUSCULE)' />
        </div>

        <div className="genre-anniv">
          <DatePicker
            selected={formData.birthdate}
            onChange={handleDateChange}
            locale="fr"
            placeholderText="Date de naissance"
            className="form-control"
            dateFormat="dd/MM/yyyy"
            maxDate={new Date()}
            showMonthDropdown
            showYearDropdown
            dropdownMode="select"
            name="birthdate"
          />

          <select className="form-control" name="gender" value={formData.gender} onChange={handleChange} required>
            <option value="">Genre</option>
            <option value="man">Homme</option>
            <option value="woman">Femme</option>
            <option value="other">Autre</option>
          </select>
        </div>

        {erreur && <p style={{ color: 'red' }}>{erreur}</p>}

        <input type="email" className="email-sub" name="email" value={formData.email}
          onChange={handleChange} placeholder='Email' required />

        <input type="tel" className="form-control" name="phoneNumber" value={formData.phoneNumber}
          onChange={handleChange} placeholder='Téléphone (ex: +33612345678)' required />

        <input type="password" className="password-sub" name="password" value={formData.password}
          onChange={handleChange} placeholder='Mot de passe' required
          // pattern="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\w\s]).{8,}$"
          title="Le mot de passe doit contenir au moins 8 caractères, une majuscule, une minuscule, un chiffre et un caractère spécial." />

        <label className="form-check-label">
          <input type="checkbox" name="newsletter" className="form-check-input" /> J'accepte de recevoir la newsletter
        </label>

        <span className='question'>Déjà inscrit(e)?</span>

        <div className="btn-group">
          <button className="submit-connex"><Link to="/Connexion">Connexion</Link></button>
          <button type="submit" className="submit-envoi">Valider</button>
        </div>
      </form>
    </div>
  );
}

export default FormRegistration;
