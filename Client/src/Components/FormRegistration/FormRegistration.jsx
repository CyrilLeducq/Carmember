import { useState, useRef } from 'react';
import '../FormRegistration/FormRegistration.css';

function FormRegistration() {
  const [step, setStep] = useState(1);
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

  const calculerAge = (dateStr) => {
    const dateNaissance = new Date(dateStr);
    const aujourdHui = new Date();
    let age = aujourdHui.getFullYear() - dateNaissance.getFullYear();
    const m = aujourdHui.getMonth() - dateNaissance.getMonth();
    if (m < 0 || (m === 0 && aujourdHui.getDate() < dateNaissance.getDate())) {
      age--;
    }
    return age;
  };

  const nextStep = () => {
    const form = formRef.current;
    if (form && form.checkValidity()) {
      if (step === 2) {
        const age = calculerAge(formData.birthdate);
        if (age < 18) {
          setErreur("Tu n'es pas majeur.");
          return;
        } else {
          setErreur('');
        }
      }
      setStep(prev => prev + 1);
    } else {
      form.reportValidity();
    }
  };

  const prevStep = () => setStep(prev => prev - 1);

  const handleSubmit = (e) => {
    e.preventDefault();
    const form = formRef.current;
    if (form && form.checkValidity()) {
      console.log("Données finales :", formData);
      alert('Formulaire validé !'      );
    } else {
      form.reportValidity();
    }
  };

  return (
    <div className='contenant'>
      <form ref={formRef} onSubmit={handleSubmit}>
        {step === 1 && (
          <>
            <label htmlFor="firstName">Prénom</label>
            <input
              className="form-control"
              id="firstName"
              name="firstName"
              value={formData.firstName}
              onChange={handleChange}
              required
            />
            <label htmlFor="lastName">Nom</label>
            <input
              className="form-control"
              id="lastName"
              name="lastName"
              value={formData.lastName}
              onChange={handleChange}
              required
            />

            <button type="button" className="btn btn-primary" onClick={nextStep}>Suivant</button>
          </>
        )}

        {step === 2 && (
          <>
            <fieldset className="btn-group" role="group" aria-label="Choix du genre">
              <legend>Genre</legend>
              <input type="radio" className="btn-check" name="genre" id="man" value="man"
                checked={formData.genre === 'man'} onChange={handleChange} required />
              <label className="btn btn-outline-primary" htmlFor="man">Homme</label>

              <input type="radio" className="btn-check" name="genre" id="woman" value="woman"
                checked={formData.genre === 'woman'} onChange={handleChange} />
              <label className="btn btn-outline-primary" htmlFor="woman">Femme</label>

              <input type="radio" className="btn-check" name="genre" id="other" value="other"
                checked={formData.genre === 'other'} onChange={handleChange} />
              <label className="btn btn-outline-primary" htmlFor="other">Autre</label>
            </fieldset>

            <label htmlFor="birthdate">Date de naissance :</label>
            <input
              type="date"
              id="birthdate"
              name="birthdate"
              value={formData.birthdate}
              onChange={handleChange}
              required
            />

            {erreur && <p style={{ color: 'red' }}>{erreur}</p>}

            <div className="d-flex gap-2">
              <button type="button" className="btn btn-secondary" onClick={prevStep}>Retour</button>
              <button type="button" className="btn btn-primary" onClick={nextStep}>Suivant</button>
            </div>
          </>
        )}

        {step === 3 && (
          <>
            <label htmlFor="inputEmail">Votre adresse mail</label>
            <input
              type="email"
              className="form-control"
              id="inputEmail"
              name="email"
              value={formData.email}
              onChange={handleChange}
              required
            />

            <label htmlFor="inputPassword">Mot de passe</label>
            <input
              type="password"
              className="form-control"
              id="inputPassword"
              name="password"
              value={formData.password}
              onChange={handleChange}
              required
              pattern="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\w\s]).{8,}$"
              title="Le mot de passe doit contenir au moins 8 caractères, une majuscule, une minuscule, un chiffre et un caractère spécial."
            />
            <div className="d-flex gap-2">
              <button type="button" className="btn btn-secondary" onClick={prevStep}>Retour</button>
              <button type="submit" className="btn btn-success">S'inscrire</button>
            </div>
          </>
        )}
      </form>
    </div>
  );
}
export default FormRegistration;
