import React from 'react'
import Button from '../../../../components/inputs/button/button'

function ActionButtons(props) {
	return(
		<div className={props.className}>
			{
				props.isFirstSlide
					? null
					: <Button type='main' style='primary' text='Previous' onClick={props.onPrevious}/>
			}
			{

				props.isLastSlide
					? <Button type='main' style='primary' text='Next' onClick={props.onNext}/>
					: <Button type='main' style='primary' text='Create new account' onClick={props.onSubmit}/>
			}
		</div>
	)
}
export default ActionButtons