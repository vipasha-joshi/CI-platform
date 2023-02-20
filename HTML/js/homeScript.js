// const itemList = document.querySelector('.item-list');
// const gridViewBtn = document.getElementById('grid-active-btn');
// const detailsViewBtn = document.getElementById('details-active-btn');

// gridViewBtn.classList.add('active-btn');

// gridViewBtn.addEventListener('click', () => {
//     gridViewBtn.classList.add('active-btn');
//     detailsViewBtn.classList.remove('active-btn');
//     itemList.classList.remove('details-active');
// });

// detailsViewBtn.addEventListener('click', () => {
//     detailsViewBtn.classList.add('active-btn');
//     gridViewBtn.classList.remove("active-btn");
//     itemList.classList.add("details-active");
// });

function showList(e) {
    var $gridCont = $('.grid-container');
    e.preventDefault();
    $gridCont.hasClass('list-view') ? $gridCont.removeClass('list-view') : $gridCont.addClass('list-view');
  }
  function gridList(e) {
    var $gridCont = $('.grid-container')
    e.preventDefault();
    $gridCont.removeClass('list-view');
  }
  
  $(document).on('click', '.btn-grid', gridList);
  $(document).on('click', '.btn-list', showList);

  const checkboxes = document.querySelectorAll(".checkbox");
  
  const filterList = document.getElementById("selected-filters");
  
  var listArray = [];
  
  for(var checkbox of checkboxes){
      checkbox.addEventListener('click', function(){
          if(this.checked == true){
              listArray.push(this.value);
              filterList.innerHTML = listArray.join(' / ');
              filterList.createElement('p');
  
              console.log(this.value);
          }
          else{
              console.log('you unchecked the checkbox');
              listArray = listArray.filter(e => e !== this.value);
              filterList.innerHTML = listArray.join(' / ');
          }
      })
  }