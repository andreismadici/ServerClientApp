<template>
  <div id="app">
    <Header v-on:trimite-comanda="trimiteComanda"/>
    <AddSlabComanda v-on:add-slabcomanda="addSlabComanda"/>
    <SlabComanda v-bind:slabComandas="slabComanda" v-on:del-slabComanda="deleteSlabComanda" />
  </div>
</template>

<script>
import Header from '../components/layout/Header';
import SlabComanda from '../components/SlabComanda';
import AddSlabComanda from '../components/AddSlabComanda';
import axios from 'axios';


export default {
  name: 'About',
  components: {
    Header,
    SlabComanda,
    AddSlabComanda
  },
  data() {
    return{
      slabComanda: [
       
      ],
      idClient: '',
      idComanda: '',
      taiat: false,
      idSlab: []
    }
  },

  methods: {
    ceva(id) {
        
        this.idComanda = id;
        
    },
    leaving() {
        if(this.idComanda == '')
            alert(this.idComanda);
        else
        {
          alert(this.idComanda);
        }
    },
    deleteSlabComanda(IdSC) {
      
      axios.delete(`http://localhost:5000/api/slabcomanda/${IdSC}`)
      .then(this.slabComanda = this.slabComanda.filter(slab => slab.idSC != IdSC))
      .catch(err => console.lod(err));
    },
    addSlabComanda(newSlabComanda)
    {
      
      const idC = this.idComanda;
      const {material,lungime,latime} = newSlabComanda;
      axios.post("http://localhost:5000/api/slabcomanda", {
        material, lungime, latime, idC})
      .then(res => this.slabComanda = [...this.slabComanda, res.data])
      .catch(err=>console.log(err));

      
    },
    adaugaLista(list)
    {
      this.idSlab = list;
      console.log(list);
      if((this.idSlab) == '')
      {
        alert("Comanda s-a finalizat cu succes");
        this.slabComanda = [];
        this.idComanda = '';
        const id = this.idClient;
        axios.post("http://localhost:5000/api/comanda", {id})
        .then(res => this.idComanda = res.data);
      }
      else
      {
         alert("Nu s-a putut efectua comanda!"); //Enumerat placiile pt care nu s-a putut face taierea
         /*for(var prop in this.idSlab)
          {
              const id = prop;
              console.log(prop);
              axios.get(`http://localhost:5000/api/slabcomanda/${id}`)
              .then(res => alert("Placa de Lungime = " + res.data.lungime + " si de Latime =" + res.data.latime + " nu este momentan in stoc!"));

          }*/
          this.idSlab.forEach(element => { 
            axios.get(`http://localhost:5000/api/slabcomanda/${element}`)
              .then(res => alert("Placa de Lungime = " + res.data.lungime + " si de Latime =" + res.data.latime + " nu este momentan in stoc!"));
          });

           
         
      }
    },
    trimiteComanda(){
      
      axios.get(`http://localhost:5000/api/taiere/${this.idComanda}`)
      .then(res => this.adaugaLista(res.data))
      .catch(err => console.log(err));
      
    }
  },
  created() {
    
      this.idClient = this.$route.params.idClient;
      
      const id = this.idClient;
      
      axios.post("http://localhost:5000/api/comanda", {id})
      .then(res => this.ceva(res.data));
   
  }, 

  
}
</script>

<style scoped>
*{
  box-sizing: border-box;
  margin: 0;
  padding: 0;
}

body{
  font-family: Arial, Helvetica, sans-serif;
  line-height: 1.4;
}

.btn {
  display: inline-block;
  border: none;
  background: #555;
  color: #fff;
  padding: 7px 20px;
  cursor: pointer;
}

.btn:hover{
  background: #666;
}
</style>
