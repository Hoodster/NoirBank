function RegistrationScene() {
    return (
        <form>
            <h1>Welcome to NoirBank</h1>
            <div>
                <h2>Part 1</h2>
                <input name='userFName' placeholder='first name'></input>
                <input name='userLName' placeholder='last name'></input>
            </div>
            <div>
                <h2>Part 2</h2>
                <input name='userEmail' type='email' placeholder='email'></input>
            </div>
            <div>
                <h2>Part3</h2>
                <input name='userID' placeholder='id number'></input>
                <input name='userIDNum' placeholder='id card number'></input>
            </div>
            <div>
                <h2>Part4</h2>
                <div>
                    <input name="userAddrStreet" placeholder='street'></input>
                </div>
                <div>
                    <input name="userAddrBulding" placeholder='building'></input>
                    <input name="userAddrApartment" placeholder='apartment'></input>
                </div>
                <div>
                    <input name="userAddrPostal" placeholder='postal code'></input>
                    <input name="userAddrCity" placeholder='city'></input>
                </div>
                <input name="userAddrCountry" placeholder='country'></input>
            </div>
            <div>
                <h2>Part5</h2>
                <input name='userPsswd' type='password' placeholder='password'></input>
                <input type='submit' value='Create new account'></input>
            </div>
        </form>
    )
}

export default RegistrationScene