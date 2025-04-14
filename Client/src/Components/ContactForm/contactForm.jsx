import React, { useState } from 'react';
import "./contactForm.css"
const ContactForm = () => {
  const [formData, setFormData] = useState({
    email: '',
    subject: '',
    message: '',
  });

  const [errors, setErrors] = useState({});
  const [submitted, setSubmitted] = useState(false);

  const handleChange = (e) => {
    setFormData({ ...formData, [e.target.name]: e.target.value });
  };

  const validate = () => {
    const newErrors = {};
    if (!formData.email.includes('@')) {
      newErrors.email = 'Email invalide';
    }
    if (!formData.subject.trim()) {
      newErrors.subject = 'Le sujet est requis';
    }
    if (!formData.message.trim()) {
      newErrors.message = 'Le message est requis';
    }
    return newErrors;
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    const validationErrors = validate();
    if (Object.keys(validationErrors).length === 0) {
      console.log('Formulaire envoyé !', formData);
      setSubmitted(true);
      setFormData({ email: '', subject: '', message: '' });
      setErrors({});
    } else {
      setErrors(validationErrors);
      setSubmitted(false);
    }
  };

  return (
    <form onSubmit={handleSubmit} className="form-contenant">
      <div>
        <input
          type="email"
          name="email"
          value={formData.email}
          onChange={handleChange}
          className="email"
          placeholder='Email'
        />
        {errors.email && <p className="error-messag">{errors.email}</p>}
      </div>

      <div>
        <input
          type="text"
          name="subject"
          value={formData.subject}
          onChange={handleChange}
          className="subject"
          placeholder='Sujet'
        />
        {errors.subject && <p className="error-messag">{errors.subject}</p>}
      </div>

      <div>
        <textarea
          name="message"
          value={formData.message}
          onChange={handleChange}
          className="message"
          rows="5"
          placeholder='Message'
        />
        {errors.message && <p className="error-messag">{errors.message}</p>}
      </div>

      <button type="submit" className="submit">
        Envoyer
      </button>

      {submitted && <p className="error-messag">Message envoyé avec succès !</p>}
    </form>
  );
};

export default ContactForm;
