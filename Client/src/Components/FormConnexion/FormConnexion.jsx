import { useState } from "react";
import "../FormConnexion/formConnexion.css";

function FormConnexion() {
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [remember, setRemember] = useState(false);
    const [error, setError] = useState("");

    const handleSubmit = async (e) => {
        e.preventDefault();
        setError("");

        try {
            const response = await fetch("http://localhost:5104", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify({ email, password, rememberMe: remember }),
            });
            const data = await response.json();
            if (!response.ok) {
                setError(data.message || "Erreur de connexion");
                return;
            }
            console.log("✅ Connecté :", data);
            alert("Connexion réussie !");
        } catch (err) {
            console.error("❌ Erreur réseau :", err);
            setError("Erreur réseau, réessayez.");
        }
    };
    return (
        <div className="form-connexion-contenant">
            <form onSubmit={handleSubmit}>
                <div className="Connexion-email">
                    <input type="email" className="form-control-connect" id="inputEmail" placeholder="Email" value={email}
                        onChange={(e) => setEmail(e.target.value)}
                        required
                    />
                </div>
                <div className="connexion-mdp">
                    <input type="password" className="form-control-connect" id="inputPassword" placeholder="Mot de passe"
                        value={password} onChange={(e) => setPassword(e.target.value)}
                        required
                    />
                </div>
                <label className="form-check-label">
                    <input type="checkbox" name="newsletter" className="form-check-input" checked={remember} onChange={(e) =>
                        setRemember(e.target.checked)}
                    />{" "}
                    Se souvenir de moi
                </label>

                {error && <p className="error-message">{error}</p>}

                <div className="envoi">
                    <button type="submit" className="submit">
                        Connexion
                    </button>
                </div>
            </form>
        </div>
    );
}

export default FormConnexion;