import React from 'react'
import './make-transfer-form.scss'

function MakeTransferForm() {
	return (
		<>
			<h5 className='make-transfer-title'>From</h5>
			<select>
				<option value={'1'}>Account 1</option>
				<option value={'2'}>Account 2</option>
				<option value={'3'}>Account 3</option>
				<option value={'4'}>Account 4</option>
				<option value={'5'}>Account 5</option>
				<option value={'6'}>Account 6</option>
			</select>
			<h5 className='make-transfer-title'>To</h5>
			<input placeholder='recipient acc. number'/>
			<h5 className='make-transfer-title'>Amount</h5>
			<div>
				<input placeholder='0.00'/>
				<span> PLN</span>
			</div>
		</>
	)
}

export default MakeTransferForm