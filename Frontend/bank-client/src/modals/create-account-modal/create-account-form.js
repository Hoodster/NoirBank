import React from 'react'

function CreateAccountForm() {
	return (
		<>
			<h5>Account type</h5>
			<select>
				<option value={'Standard'}>Standard</option>
				<option value={'Business'}>Business</option>
				<option value={'Saving'}>Saving</option>
				<option value={'Investment'}>Investment</option>
			</select>
			<h5>Account name</h5>
			<input placeholder='name'></input>
		</>
	)
}

export default CreateAccountForm