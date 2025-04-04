import insta from "../../assets/insta.png"
import facebook from "../../assets/facebook.png"
import x from "../../assets/x.png"
import youtube from "../../assets/youtube.png"
import "../Footer/footer.css"
import Logo from "../../assets/Logo.png"


function Footer() {
    return ( 
        <div className="footer-components">
            <div className="haut">
               <ul className="footer-liens">
                <li>Qui sommes nous? </li>
                <li>Information Légales</li>
                <li>Cookies</li>
                <li>Contact</li>
            </ul> 
            <ul className="footer-reseau">
                <li><a href=""><img src={facebook} alt="" className="logo-reseau" /></a></li>
                <li><a href=""><img src={x} alt=""className="logo-reseau" /></a></li>
                <li><a href=""><img src={insta} alt=""className="logo-reseau" /></a></li>
                <li><a href=""><img src={youtube} alt=""className="logo-reseau" /></a></li>
            </ul>  
            </div>
            <div className="bas">
                <div className="bas_logo"><img src={Logo} width={50} alt="" /></div>
                <span>Car'Member, 2025 ©</span>
            </div>
           
        </div>
     );
}

export default Footer;