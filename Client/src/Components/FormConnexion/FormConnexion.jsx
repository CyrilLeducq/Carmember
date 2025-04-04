
function FormConnexion() {
return (
<div>
    <form>
        <div class="mb-3">
            <label for="inputEmail" class="form-label">Votre adresse mail</label>
            <input type="email" class="form-control" id="inputEmail" required />
        </div>
        <div class="mb-3">
            <label for="inputPassword" class="form-label">Mot de passe</label>
            <input type="password" class="form-control" id="inputPassword" required/>
        </div>
        <button type="submit" class="btn btn-primary">Connexion</button>
    </form>
</div>
);
}

export default FormConnexion;