import "../FormConnexion/formConnexion.css"

function FormConnexion() {
return (
<div className="form-connexion-contenant">
    <form>
        <div class="Connexion-email">
            <input type="email" class="form-control-connect" id="inputEmail" placeholder="Email" required />
        </div>
        <div class="connexion-mdp">
            <input type="password" class="form-control-connect" id="inputPassword" placeholder="Mot de passe" required/>
        </div>
        <label className="form-check-label">
          <input type="checkbox" name="newsletter" className="form-check-input" /> Se souvenir de moi
        </label>
        <div className="envoi">
            <button type="submit" class="submit">Connexion</button>
        </div>
        
    </form>
</div>
);
}

export default FormConnexion;